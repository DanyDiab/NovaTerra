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
    public bool increaseProgress;

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
            changeState();
            determineChangeAmount();
            changeProgress();
            disableMoveShoot();
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
                // check for negative values
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
        if(increaseProgress){
            changeAmount = 1;
            changeInterval = 300;
        }
        else if (currProgress > 0){
            changeAmount = -1;
            changeInterval = 100;
        }
        else{
            changeAmount = 0;
            changeInterval = 0;
        }
    }
    private void changeState(){
        if(Input.GetKeyDown(KeyCode.F)){
            if(isPlayerInZone()){
                increaseProgress = !increaseProgress;
            }
        }
    }
    private void disableMoveShoot(){
        if(increaseProgress){
            player.directionLocked = true;
            player.shootLocked = true;
        }
        else{
            player.directionLocked = false;
            player.shootLocked = false;
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



// check if F is pressed:
// check if is in zone:
// if true and if the zone isnt complete, start increasing.
// keep increasing until zone == 100 if the player presses F again. 
