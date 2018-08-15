using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InfoPlayer {

    public static float score = 0f;
    

    public static void setScore(float sc) {
        score = sc;
    }

    public static float getScore() {
        return score;
    }
}
