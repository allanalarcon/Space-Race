using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouseOverNext : MonoBehaviour {

    AudioSource sound;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject LoadingPanel;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}

    void OnMouseEnter() {
        sound.Play();        
    }

    void OnMouseDown() {
    	if (Panel1.activeSelf == true) {
    		Panel1.SetActive(false);
    		Panel2.SetActive(true);
    		Panel3.SetActive(false);
    	}
    	else if (Panel2.activeSelf == true) {
    		Panel1.SetActive(false);
    		Panel2.SetActive(false);
    		Panel3.SetActive(true);
    	}
    	else if (Panel3.activeSelf == true) {
    		InfoPlayer.setMode(1);
            saveContinue(0);
            LoadingPanel.SetActive(true);            
    	}
    }

    private void saveContinue(int actual) {
        PlayerPrefs.SetInt("Continue", actual);
    }
}
