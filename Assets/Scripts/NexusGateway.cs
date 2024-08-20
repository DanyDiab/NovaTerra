using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NexusGateway : Interactable
{

    // Update is called once per frame
    void Update()
    {
        base.Update();
        loadNexus();
    }
    
    void loadNexus(){
        if(interacted){
            SceneManager.LoadScene("Nexus",LoadSceneMode.Single);
        }
    }
}
