using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float score = 0f; // tiempo en segundos
    private int life = 3;
    //Destroyable nave;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isAlive()) {
            score += Time.deltaTime;
        } else {
            // presentar game over
            print("Score: " + score);
        }
	}

    public bool isAlive() {
        return life > 0;
    }

    public void impact() {
        life--;
    }

}
