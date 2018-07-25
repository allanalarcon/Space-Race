using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void cambiarEscena(string escena){
		SceneManager.LoadScene(escena);
	}

	public void salir(){
		Application.Quit();
	}

}
