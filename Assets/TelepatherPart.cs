using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelepatherPart : MonoBehaviour{
    public Player player;
    public int interactRadius;
    private bool update;
    void Start()
    {
        interactRadius = 20;
    }
    void Update(){
    //    if(Input.GetKeyDown(KeyCode.F)){
            // if(mathHandler.calculateDistanceBetween2Vectors(player.transform.position, transform.position) < interactRadius){
                update = !update;
            // }
        if(update){
            pickUp();
       }
       }

    // }

    private void pickUp(){
        
    }
}
