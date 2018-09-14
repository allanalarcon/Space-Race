using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaScript : MonoBehaviour {
    
    public GameObject bala;    
    public Slider weapon;
    ShipMovement sm;

    // Use this for initialization
    void Start () {
        sm = GetComponentInParent<ShipMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space) && InfoPlayer.getMode()!=3 && weapon.value < 0.95f && PlayerPrefs.GetInt("onPause")==0 && sm.IcanShoot()) {
            GetComponent<AudioSource>().Play();
            Instantiate(bala, transform.position, bala.transform.rotation);
        }
    }

}
