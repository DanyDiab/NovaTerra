using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathHandler
{

    public static float calculateDistanceBetween2Vectors(Vector2 pos1, Vector2 pos2){
        return (pos1 - pos2).magnitude;
    }
    public static Vector2 calculateDirectionBetween2Vectors(Vector2 pos1, Vector2 pos2){
        Vector2 direction = pos1 - pos2;
        if (direction == Vector2.zero) {
            return Vector2.zero;
        }
        return direction.normalized;
    }
    public static Vector2 getRandPos(float xMin, float xMax, float yMin, float yMax){
        float randx = Random.Range(xMin, xMax);
        float randy = Random.Range(yMin, yMax);
        Vector2 pos = new Vector2(randx, randy);
        return pos;
    }
} 
