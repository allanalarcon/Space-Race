using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHole : MonoBehaviour {

    [SerializeField]
    private GameObject HoleOut;

	// Use this for initialization
	void Start () {
		
	}
	

    public void Stop() {

        GetComponent<ParticleSystem>().Stop();
        GameObject.Find("InHole").SetActive(false);
        GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();

        // Escupir nave
        Instantiate(HoleOut);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-8f, -1.621881f, 0f);
        player.GetComponent<Animator>().Play("shipOut");
        player.GetComponent<ShipMovement>().blockUnblockShoot();
    }
}
