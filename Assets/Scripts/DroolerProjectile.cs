using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroolerProjectile : Projectile
{
    // Start is called before the first frame update
    public Drooler droolerThatShot;

    void Start()
    {
        speed = 70;
        damage = 15;
        range = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void calculateDir(){
        direction = MathHandler.calculateDirectionBetween2Vectors(player.transform.position, droolerThatShot.transform.position);
    }
}
