using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCooldowns : MonoBehaviour
{
    public static AllCooldowns instance;
    void Awake(){
        if(instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
