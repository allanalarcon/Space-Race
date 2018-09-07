using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

    AudioSource sound;

    // Use this for initialization
    private void Start() {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().incrementShieldPower();
            sound.Play();
            Destroy(gameObject);
        } else if (collision.CompareTag("Finish")) {
            Destroy(gameObject);
        }
    }
}
