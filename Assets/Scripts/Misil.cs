using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour {
    
    private bool estallando = false;
    private float radioExplosion = 30f;
    public float velocidad = 20f;
    private Animator anim;
    public float radio = 0.3f;
    private CircleCollider2D expansion;
    private AnimatorStateInfo stateInfo;
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();        
        expansion = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {		
        transform.position += transform.right * velocidad * Time.deltaTime;       
        
        if (estallando && expansion.radius < radioExplosion) {            
            expansion.radius += 0.5f;
        }
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("misilExplosion") && stateInfo.normalizedTime >= 1) {
            foreach (Collider2D col in GetComponents<Collider2D>()) {
                col.enabled = false;
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Obstaculo")) {            
            GetComponentInParent<AudioSource>().Stop();            
            anim.SetBool("estallando", true);
            sound.Play();
            estallando = true;
        }
    }

}
