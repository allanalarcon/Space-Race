﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void cambiarEscena(string escena){
        if (escena == "Over"){
            SceneManager.LoadScene("Game");
        }
        else if (escena == "Game"){
            InfoPlayer.setMode(3);
            SceneManager.LoadScene("Game");
        }
        else if (escena == "Disparar"){
            InfoPlayer.setMode(2);
            SceneManager.LoadScene("Game");
        }
        else if (escena == "Story"){
            InfoPlayer.setMode(1);
            SceneManager.LoadScene("Game");
        }
		else {
            SceneManager.LoadScene(escena);
        }
	}

	public void salir(){
		Application.Quit();
	}
}
