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
            GetComponentInParent<AudioSource>().Pause();            
            
            if (GetComponent<PolygonCollider2D>().enabled) {
                sound.Play();
            }
            anim.SetBool("estallando", true);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    	if (!(collision.name == "BlackHoleIn(Clone)")){
    		if (collision.CompareTag("Obstaculo")){
    			collision.gameObject.GetComponent<Animator>().SetInteger("impactos", 0);
    			collision.gameObject.GetComponent<AudioSource>().Play();
    			Destroyable.kills++;
    		}
    	}
    }

    public void finAnimation() {
        Destroy(gameObject);
    }
}
