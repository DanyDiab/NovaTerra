using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drooler : Enemy
{
    public DroolerProjectile projectile;


    void Update()
    {
        move();
        // attack();
    }
    private void attack(){
        if(MathHandler.calculateDistanceBetween2Vectors(player.transform.position, transform.position) <= movRange && attackReady){
            isAttacking = true;
            attackReady = false;
            chargeUpComplete = false;
        }
        if(isAttacking){
            if(!chargeUpComplete){
                if(chargeUpCH.Cooldown(chargeUpDuration)){
                    chargeUpComplete = true;
                    Instantiate(projectile,transform.position,transform.rotation);
                    projectile.droolerThatShot = this;
                    projectile.calculateDir();
                }
            }
            if(chargeUpComplete){
                if(attackCH.Cooldown(attackDuration)){
                    isAttacking = false;
                    attackReady = true;
                    chargeUpComplete = false;
                }
            }
        }
    }
}
