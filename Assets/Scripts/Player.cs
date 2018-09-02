using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public static float score = 0f; // tiempo en segundos
    private int life = 3;
    private int shieldPower = 0;
    //Destroyable nave;
    

    // Use this for initialization
    void Start() {        
    }

    // Update is called once per frame
    void Update() {
        if (isAlive()) {
            if (InfoPlayer.getMode() == 3){
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