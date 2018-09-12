using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {
            // Animación de transición
            GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();
            //GameObject.Find("InHole").SetActive(true);            

            sound.Play();
            collision.gameObject.GetComponent<Player>().setScore(Random.Range(-15, 15));
        } else {
            Destroy(collision.gameObject);
        }
    }

    public void desactivarAnimacion() {
        GameObject.Find("InHole").SetActive(false);
        GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();
        sound.Play();
        

        //Escupir nave

    }
}
