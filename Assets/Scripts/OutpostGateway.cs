using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutpostGatway : Interactable
{

    // Update is called once per frame
    void Update()
    {
        base.Update();
        loadOutpost();
    }
    
    void loadOutpost(){
        if(interacted){
            SceneManager.LoadScene("Outpost",LoadSceneMode.Single);
        }
    }
}
