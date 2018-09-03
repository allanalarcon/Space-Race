using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void cambiarEscena(string escena){
        if (escena == "Again"){
            SceneManager.LoadScene(InfoPlayer.getMode()==1? "Story":"Game");
        }
        else if (escena == "Survival"){
            InfoPlayer.setMode(3);
            SceneManager.LoadScene("Game");
        }
        else if (escena == "Shooter"){
            InfoPlayer.setMode(2);
            SceneManager.LoadScene("Game");
        }
        else if (escena == "Story"){
            InfoPlayer.setMode(1);
            SceneManager.LoadScene("Story");
        }
		else {
            SceneManager.LoadScene(escena);
        }
	}

	public void salir(){
		Application.Quit();
	}
}
