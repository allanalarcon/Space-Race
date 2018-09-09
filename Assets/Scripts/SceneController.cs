using System.Collections;
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
        }
		else {
            SceneManager.LoadScene(escena);
        }
	}

	public void salir(){
		Application.Quit();
	}
}
