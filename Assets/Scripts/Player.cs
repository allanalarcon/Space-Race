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
            score += Time.deltaTime;
        } else {
            // presentar game over
            InfoPlayer.score = score;
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