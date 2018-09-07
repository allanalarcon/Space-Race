using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaScript : MonoBehaviour {
    
    public GameObject bala;    
    public Slider weapon;    

    // Use this for initialization
    void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space) && InfoPlayer.getMode()!=3 && weapon.value < 0.95f) {
            GetComponent<AudioSource>().Play();
            Instantiate(bala, transform.position, bala.transform.rotation);
        }
    }

}
