using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownHandler : MonoBehaviour{
    private float timer;
    private float cdSecs;
    public static CooldownHandler instance;
    
  
    public bool Cooldown(int cdInMs){
        cdSecs = msToSecs(cdInMs);
        timer += Time.deltaTime;
        if(timer >= cdSecs){
            timer = 0;
            return true;
        }
        else{
            return false;
        }
    }

    public void Reset(){
        timer = 0;
    }
    private float msToSecs(int ms){
        return (float) ms/1000;
    }
}
