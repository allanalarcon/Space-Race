﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static float score = 0f;
    private int life = 3;
    private int shieldPower = 0;        

    // Use this for initialization
    void Start() {
        score = 0f;
    }

    // Update is called once per frame
    void Update() {
        if (isAlive()) {
            if (InfoPlayer.getMode() == 3 || InfoPlayer.getMode() == 1) {
                score += Time.deltaTime;
            }
            else if (InfoPlayer.getMode() == 2){
                score = Destroyable.kills;
            }
        } else {
            levelComplete();
        }
    }

    public void resetScore(){
        score = 0f;
    }
    
    public void setScore(float newScore) {
        if (score+newScore < 0) {
            score = 0f;
        } else if (score+newScore > 100) {
            score = 100f;
        }
        else {
            score += newScore;
        }
    }

    public void levelComplete() {
        //Destruir obstaculos restantes y llegar al planeta
        score = 0f;
        InfoPlayer.score = 0f;
    }

    public bool isAlive() {
        return life > 0;
    }

    public void impact() {
        if (shieldPower >= 1) {
            shieldPower--;
            InfoPlayer.setShield(shieldPower);
        } else {
            life--;
        }        
    }

    public int getLifes() {
        return life;
    }

    public float getScore() {
        return score;
    }

    public int getShieldPower() {
        return shieldPower;
    }

    public void incrementShieldPower() {
        shieldPower = 2;
        InfoPlayer.setShield(2);
    }

    public void decrementShieldPower() {
        shieldPower--;
        InfoPlayer.setShield(shieldPower);
    }

    public void toGameOver() {
        InfoPlayer.score = score;
        score = 0f;
        Destroyable.kills = 0;        
  
        SceneManager.LoadScene("GameOver");        
    }

}