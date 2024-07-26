using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMouth : Enemy
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        move();
        if(collidedWithPlayer){
            collided();
        }
        else{
            attack();
        } 
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
                    attackDir = MathHandler.calculateDirectionBetween2Vectors(player.transform.position, transform.position);
                    chargeUpComplete = true;
                }
            }
            if(chargeUpComplete){
                transform.Translate(attackDir * attackSpeed * Time.deltaTime);
                if(attackCH.Cooldown(attackDuration)){
                    isAttacking = false;
                    attackReady = true;
                    chargeUpComplete = false;
                }
            }
        }
    }

}
