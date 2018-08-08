using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    public string destroyState;
    public float timeForDisable;
    public bool player = false;
    private int impactos = 0;

    Animator anim;
    AudioSource sound;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1) {
            Destroy(gameObject);
        }
	}


    IEnumerator OnCollisionEnter2D(Collision2D collision) {
        bool destruir = false;
        if (player) {            
            if (collision.collider.CompareTag("Obstaculo")) {
                impactos++;
            }
            destruir = impactos == 3;
        } else {
            destruir = collision.collider.CompareTag("Disparo") || collision.collider.CompareTag("Player");
        }
        if (destruir) {
            anim.Play(destroyState);
            sound.Play();

            yield return new WaitForSeconds(timeForDisable);
            
            foreach (Collider2D col in GetComponents<Collider2D>()) {
                col.enabled = false;
            }
        }
    }
}
