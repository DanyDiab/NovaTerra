using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isBeingInteracted;
    public bool openMenu;
    // Start is called before the first frame update
    void Start()
    {
        isBeingInteracted = false;
        openMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(openMenu){
            
        }
    }
    void interact(){
        isBeingInteracted = !isBeingInteracted;
        openMenu = !openMenu;
    }
}
