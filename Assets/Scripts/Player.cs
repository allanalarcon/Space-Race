using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static float score = 0f;
    private int life = 3;
    private int shieldPower = 0;
    private bool endAnim = false;
    

    // Use this for initialization
    void Start() {        
    }

    // Update is called once per frame
    void Update() {
        if (isAlive() && !endAnim) {
            if (InfoPlayer.getMode() == 3 || InfoPlayer.getMode() == 1) {
                score += Time.deltaTime;
            }
            else if (InfoPlayer.getMode() == 2){
                score = Destroyable.kills;
            }
        } else {
            // presentar game over
            toGameOver();            
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
        if (shieldPower >= 1) {
            shieldPower--;
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
    }

    public void decrementShieldPower() {
        shieldPower--;
    }

    public void toGameOver() {
        InfoPlayer.score = score;
        score = 0;
        Destroyable.kills = 0;        
  
        SceneManager.LoadScene("GameOver");        
    }

    public void loadGameOver() {
        endAnim = true;
        print("game over");
    }
}