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

    public void saveScore() {
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);

        //Guardar en archivo
    }


}
