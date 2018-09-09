using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Disparo")) {
            Destroy(collision.gameObject);
        } else if (collision.CompareTag("Misil")) {
            collision.gameObject.GetComponentInParent<AudioSource>().Stop();
            Destroy(collision.gameObject);
        }
    }
}
