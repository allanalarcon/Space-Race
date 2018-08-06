using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    public string destroyState;
    public float timeForDisable;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(destroyState) && stateInfo.normalizedTime >= 1) {
            Destroy(gameObject);
        }
	}


    IEnumerator OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Disparo") || collision.collider.CompareTag("Player")) {
            anim.Play(destroyState);

            yield return new WaitForSeconds(timeForDisable);
            
            foreach (Collider2D col in GetComponents<Collider2D>()) {
                col.enabled = false;
            }
        }
    }
}
