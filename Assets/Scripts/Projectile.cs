using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Projectile : MonoBehaviour{
    public int speed;
    public Vector2 direction;
    public Player player;
    public int range;
    public float distanceTraveled;
    public int damage;
    public string shotTag;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        direction = MathHandler.calculateDirectionBetween2Vectors(Camera.main.ScreenToWorldPoint(Input.mousePosition), player.transform.position);
        speed = 70;
        range = player.range;
        damage = 50;
    }

    // Update is called once per frame
    void Update(){
        moveProjectile();
    }
    public void moveProjectile(){
        Vector2 ammtToTranslate = direction * speed * Time.deltaTime;
        transform.Translate(ammtToTranslate);
        distanceTraveled += ammtToTranslate.magnitude;
        destroyPassedRange();
    }
    public void destroyPassedRange(){
        if(distanceTraveled >= range){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemy")){       
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null){
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}

