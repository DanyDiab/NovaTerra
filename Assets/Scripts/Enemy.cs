using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public int attackSpeed;
    public int hp;
    public int movRange;
    public int damage;

    public int attackDuration;
    public int knockbackTime;
    public int chargeUpDuration;
    public CooldownHandler attackCH;
    public CooldownHandler chargeUpCH;


    public Vector2 dir;
    public Vector2 attackDir;
    public bool isAttacking;
    public bool attackReady;
    public bool chargeUpComplete;
    public bool collidedWithPlayer;
    public GameLogic gameLogic;


    public Player player;
    void Start()
    {
        speed = 30;
        attackSpeed = 50;
        hp = 200;
        movRange = 20;
        attackDuration = 1000;
        chargeUpDuration = 1000;
        damage = 20;
        attackReady = true;
        chargeUpComplete = false;
        knockbackTime = 300;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameLogic = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<GameLogic>();
        attackCH = GameObject.FindGameObjectWithTag("AttackCH").GetComponent<CooldownHandler>();
        chargeUpCH = GameObject.FindGameObjectWithTag("ChargeUpCH").GetComponent<CooldownHandler>();
        transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
    }

    protected void move(){
        if(!isAttacking){
            if(MathHandler.calculateDistanceBetween2Vectors(player.transform.position, transform.position) > movRange){
                dir = MathHandler.calculateDirectionBetween2Vectors(player.transform.position, transform.position);
                transform.Translate(dir * speed * Time.deltaTime);
            }
        }
    }
    public void TakeDamage(int damage){
        hp -= damage;
        removeIfDead();
    }
    public void removeIfDead(){
        if(hp <= 0){
            Destroy(gameObject);
            gameLogic.numEnemiesAlive--;
        }
    }

    protected void collided(){
        transform.Translate(attackDir * attackSpeed/2 * Time.deltaTime);
        if(attackCH.Cooldown(knockbackTime)){
            collidedWithPlayer = false;
            attackReady = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Player player = other.GetComponent<Player>();
            if(player != null){
                player.takeDamage(damage);
                attackCH.Reset();
                collidedWithPlayer = true;
                isAttacking = false;
                attackDir *= -1;
            }
        }
    }
}
