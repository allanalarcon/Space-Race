using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InfoPlayer {

    public static float score = 0f;
    public static int gamemode = 0; //1-Story, 2-Disparar, 3-Survival
    

    public static void setScore(float sc) {
        score = sc;
    }

    public static float getScore() {
        return score;
    }

    public static void setMode(int i) {
        gamemode = i;
    }

    public static int getMode() {
        return gamemode;
    }
}
