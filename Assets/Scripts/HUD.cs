using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    Animator vida;
    Animator escudo;
    public GameObject nave;
    Player player;

	// Use this for initialization
	void Start () {
        vida = transform.GetChild(1).GetComponent<Animator>();
        escudo = transform.GetChild(2).GetComponent<Animator>();
        player = nave.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        vida.SetInteger("lifes", player.getLifes());
        escudo.SetInteger("ShieldPower", player.getShieldPower());
	}
}
