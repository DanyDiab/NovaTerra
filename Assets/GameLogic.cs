using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Player player;
    public int numEnemiesAlive;
    public BigMouth bigMouth;
    public CaptureZone captureZone;
    public int botRandBound;
    public int topRandBound;
    public int chanceToIncreaseBounds;
    public int boundIncrementVal;
    public float initialSpawnInterval;
    public float currentSpawnInterval;
    public float decreaseSpawningInterval;
    public float spawnRateIncrease;
    public int numToSpawn;
    public bool isCaptured;

    
    // Start is called before the first frame update
    void Start()
    {
        chanceToIncreaseBounds = 5;
        boundIncrementVal = 1;
        numEnemiesAlive = 0;
        initialSpawnInterval = 10f;
        decreaseSpawningInterval = 60f;
        spawnRateIncrease = 0.1f;
        botRandBound = 1;
        topRandBound = 3;
        currentSpawnInterval = initialSpawnInterval;
        Vector2 pos = MathHandler.getRandPos(-100,100,-100,100);
        Instantiate(captureZone, pos, transform.rotation);
        // StartCoroutine(spawnEnemyOnIntervals());     
        // StartCoroutine(decreaseSpawnInterval());   
    }
    IEnumerator spawnEnemyOnIntervals(){
        while(!captureZone.isComplete){
            yield return new WaitForSeconds(currentSpawnInterval);
            numToSpawn = calculateNumEnemiesToSpawn();
            spawnEnemies();
            determineIncreaseNeeded();
        }
    }
    IEnumerator decreaseSpawnInterval(){
        while(!captureZone.isComplete){
            yield return new WaitForSeconds(decreaseSpawningInterval);
            if(currentSpawnInterval > 1f){
                currentSpawnInterval -= spawnRateIncrease;
                Debug.Log("increasedSpawnRate");
            }
        }
    }

    public void spawnEnemies(){
        for(int i = 0; i < numToSpawn; i++){
            Vector2 pos = MathHandler.getRandPos(player.transform.position.x - player.transform.position.x/2, player.transform.position.x + player.transform.position.x/2, 
                player.transform.position.y - player.transform.position.y/2,player.transform.position.y + player.transform.position.y/2);
            Instantiate(bigMouth, pos, transform.rotation);
            numEnemiesAlive++;
        }
    }

    private int calculateNumEnemiesToSpawn(){
        return Random.Range(botRandBound, topRandBound);
    }

    private void increaseRandBounds(){
        botRandBound += boundIncrementVal;
        topRandBound += boundIncrementVal;
        Debug.Log("increasedBounds");
    }
    private void determineIncreaseNeeded(){
        int increaseBounds = Random.Range(0, 100);
        if(increaseBounds <= chanceToIncreaseBounds){
            increaseRandBounds();
        }
    }
}
