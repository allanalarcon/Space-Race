using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static float score = 0f;
    private int life = 3;
    private int shieldPower = 0;    
    

    // Use this for initialization
    void Start() {        
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
            // presentar game over
            InfoPlayer.score = score;
            score = 0;
            Destroyable.kills = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void setScore(float newScore) {
        score += newScore;
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
        life--;
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
}