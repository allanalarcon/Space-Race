﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	[SerializeField]
	private string sceneToLoad;

	[SerializeField]
	private Text percentText;

	[SerializeField]
	private Image progressImage;

	// En cuanto se active el objeto, se inciará el cambio de escena
	void Start () {
		//Iniciamos una corrutina, que es un método que se ejecuta 
		//en una línea de tiempo diferente al flujo principal del programa
		StartCoroutine(LoadScene());
	}

	//Corrutina
	IEnumerator LoadScene()
	{
		AsyncOperation loading;

        if (sceneToLoad.CompareTo("Again")==0) {
            if (InfoPlayer.getMode() == 1) {
            	if (getContinue() == 0){
            		sceneToLoad = "Story";
            	}
            	else {
            		sceneToLoad = "Story2";
            	}
            } else {
                sceneToLoad = "Game";
            }            
        }

        //Iniciamos la carga asíncrona de la escena y guardamos el proceso en 'loading'
        loading = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Single);

		//Bloqueamos el salto automático entre escenas para asegurarnos el control durante el proceso
		loading.allowSceneActivation = false;

		//Cuando la escena llega al 90% de carga, se produce el cambio de escena
		while (loading.progress < 0.9f) {
			
			//Actualizamos el % de carga de una forma optima 
			//(concatenar con + tiene un alto coste en el rendimiento)
			percentText.text = string.Format ("{0}%", (int)(loading.progress * 100));

			//Actualizamos la barra de carga
			progressImage.fillAmount = loading.progress;

			//Esperamos un frame
			yield return null;
		}

		//Mostramos la carga como finalizada
		percentText.text = "100%";
		progressImage.fillAmount = 1;

		//Activamos el salto de escena.
		loading.allowSceneActivation = true;


	}

	public int getContinue(){
        return PlayerPrefs.GetInt("Continue", 0);
    }

    public void setScene(string scene) {
        sceneToLoad = scene;
    }

}
