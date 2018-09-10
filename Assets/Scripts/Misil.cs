using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour {
         
    public float velocidad = 20f;
    private Animator anim;        
    private AnimatorStateInfo stateInfo;
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();                
	}
	
	// Update is called once per frame
	void Update () {		
        transform.position += transform.right * velocidad * Time.deltaTime;       

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Obstaculo")) {
            Debug.Log("Colision Misil " + collision.collider.gameObject.name);
            GetComponentInParent<AudioSource>().Pause();            
            
            if (GetComponent<PolygonCollider2D>().enabled) {
                sound.Play();
            }
            anim.SetBool("estallando", true);            
        }
    }

    public void finAnimation() {
        Destroy(gameObject);
    }
}
