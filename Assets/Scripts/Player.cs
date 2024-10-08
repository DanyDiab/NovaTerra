using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour{
    public float speed;
    public Vector2 moveInput;
    public Projectile projectile;
    public CooldownHandler shootCH;
    public int shootCD;
    public int range;
    public int hp;
    public int totalHp;
    private bool canShoot;
    public bool directionLocked;
    public bool shootLocked;
    public static Player player;

        void Start(){
        gameObject.name = "player";
        // Set the initial speed
        speed = 50f;
        range = 100;
        shootCD = 1000;
        hp = 100;
        totalHp = hp;
        directionLocked = false;
        shootLocked = false;

    }

    void Update(){
        move();
        shoot();
    }
    void Awake(){
        if(player != null){
            Destroy(gameObject);
            return;
        }
        player = this;
        DontDestroyOnLoad(gameObject);

    }
    void move(){
        if(!directionLocked){
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(moveHorizontal, moveVertical).normalized;
            transform.Translate(moveInput * speed * Time.deltaTime);
        }
    }
    void shoot(){
        if(!shootLocked){
            if(Input.GetMouseButton(0) && canShoot){
                Instantiate(projectile,transform.position, transform.rotation);
                canShoot = false;
                projectile.shotTag = "player";
            }
            else if(!canShoot){
                if(shootCH.Cooldown(shootCD)){
                    canShoot = true;
                }
            }
        }
    }
    public void takeDamage(int damage){
        hp -= damage;
    }
}
