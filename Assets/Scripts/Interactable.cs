using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isBeingInteracted;
    public bool openMenu;
    public bool playerInRange;
    public GameObject menuPanel;
    public Player player;

    // Start is called before the first frame update
    void Start(){
        isBeingInteracted = false;
        openMenu = false;
        playerInRange = false;
        menuPanel.SetActive(openMenu);
    }
    void Update(){
        if(playerInRange){
            checkInput();
        }
    }
    void interact(){
        isBeingInteracted = !isBeingInteracted;
        openMenu = !openMenu;
        menuPanel.SetActive(openMenu);
        player.directionLocked = !player.directionLocked;
        player.shootLocked = !player.shootLocked;
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
}
