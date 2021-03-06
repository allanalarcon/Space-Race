﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void cambiarEscena(string escena){
        if (escena == "Survival"){
            InfoPlayer.setMode(3);            
        }
        else if (escena == "Shooter"){
            InfoPlayer.setMode(2);            
        }
        else if (escena == "Story"){
            InfoPlayer.setMode(1);            
            
            if (getContinue() == 1){
                SceneManager.LoadScene("Continue");
            }
            else {
                saveContinue(0);
                /* //Carga de la escena con Laoding
                GameObject loadingPanel = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
                loadingPanel.GetComponent<Loading>().setScene("Introduction");
                loadingPanel.SetActive(true);
                */
                SceneManager.LoadScene("Introduction");
            }
        } else if (escena == "Story2") {
            InfoPlayer.setMode(1);
        }
        else if (escena == "Introduction"){
            saveContinue(0);
            SceneManager.LoadScene("Introduction");
        }
        else {
            SceneManager.LoadScene(escena);
        }
	}

	public void salir(){
		Application.Quit();
	}

    public int getContinue(){
        return PlayerPrefs.GetInt("Continue", 0);
    }

    public void saveContinue(int actual){
        PlayerPrefs.SetInt("Continue", actual);
    }
}
