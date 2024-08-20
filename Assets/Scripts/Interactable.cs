using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool interacted;
    public bool openMenu;
    public bool playerInRange;
    public Player player;

    // Start is called before the first frame update
    void Start(){
        interacted = false;
        playerInRange = false;
        getPlayerReference();
    }
    public void Update(){
        if(playerInRange){
            checkInput();
        }
    }
    public void interact(){
        interacted = !interacted;
    }
    void checkInput(){   
        if(Input.GetKeyDown(KeyCode.F)){
            interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
        }
    }
        void getPlayerReference(){
        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }
}
