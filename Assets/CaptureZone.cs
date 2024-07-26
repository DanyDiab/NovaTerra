using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
    public Player player;
    public CooldownHandler zoneCH;
    public GameLogic gameLogic;
    public int changeInterval;
    public int captureSize;
    public int currProgress;
    public int changeAmount;
    public bool isComplete;

    void Start(){
        captureSize = 30;
        currProgress = 0;
        changeInterval = 500;
        isComplete = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        zoneCH = GameObject.FindGameObjectWithTag("ZoneCH").GetComponent<CooldownHandler>();
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
        UpdateCaptureAreaVisual();
    }
    void Update()
    {
        if(!isComplete){
            determineChangeAmount();
            changeProgress();
        }
    }
    private bool isPlayerInZone(){
        if(MathHandler.calculateDistanceBetween2Vectors(player.transform.position, transform.position) < captureSize){
            return true;
        }
        else{
            return false;
        }
    }
    private void changeProgress(){
        if(currProgress < 100){
            if(zoneCH.Cooldown(changeInterval)){
                if(!(currProgress + changeAmount > 0)){
                    currProgress = 0;
                }
                else{
                    currProgress += changeAmount;
                }
                if(currProgress == 100){
                    isComplete = true;
                    gameLogic.isCaptured = true;
                }
            }
        }
    }
    private void determineChangeAmount(){
        if(isPlayerInZone()){
            changeAmount = 1;
            changeInterval = 300;
        }
        else{
            changeAmount = -1;
            changeInterval = 100;
        }
    }
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, captureSize);
    }
void UpdateCaptureAreaVisual()
    {
        // Set the scale of the sprite to match the capture area size
        transform.localScale = new Vector3(captureSize * 2, captureSize * 2, 1);
    }


    
}
