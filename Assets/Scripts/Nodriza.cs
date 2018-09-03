using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Nodriza : MonoBehaviour {
    
	Rigidbody2D rb;
    Animator anim;
    Vector2 Mov;
	public float Velocidad = 8f;
    public Vector2 minLimit = new Vector2(-12,-7);
    public Vector2 maxLimit = new Vector2(12,7);
    private float angle = 3f;
    private int dir = 0;
    private Animator animState;
    int impactos = 0;

    void Start () {
		rb = GetComponent<Rigidbody2D>();        
        animState = transform.GetChild(2).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool bup = Input.GetKey(KeyCode.UpArrow);
        bool bdown = Input.GetKey(KeyCode.DownArrow);        
        Mov = new Vector2(Input.GetAxis("Horizontal"),
                          Input.GetAxis("Vertical"));

        if (bup) {
            dir = 1;
        } else if (bdown) {
            dir = -1;
        } else {
            dir = 0;
        }
	}

    void FixedUpdate() {
        Vector2 newPosition = rb.position + Mov * Velocidad * Time.deltaTime;
        rb.MovePosition(fixPosition(newPosition));
        //rb.MoveRotation(angle * dir);
    }

    private void OnCollisionEnter2D(Collision2D collision) {        
        if (collision.collider.CompareTag("Obstaculo")) {
            impactos++;
            if (impactos == 2) {
                activarHumo();
                rb.gravityScale = 15f;
            }
            if (impactos < 3) {
                animState.Play("impacto");
            } else {
                transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
                desactivarHumo();
            }            
        }
    }

    private Vector2 fixPosition(Vector2 position) {
        Vector2 fixedPosition = position;
        
        fixedPosition.y = (fixedPosition.y > maxLimit.y) ? maxLimit.y : fixedPosition.y;
        fixedPosition.y = (fixedPosition.y < minLimit.y) ? minLimit.y : fixedPosition.y;
        fixedPosition.x = (fixedPosition.x > maxLimit.x) ? maxLimit.x : fixedPosition.x;
        fixedPosition.x = (fixedPosition.x < minLimit.x) ? minLimit.x : fixedPosition.x;

        return fixedPosition;
    }

    private void activarHumo() {
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
        transform.GetChild(4).GetComponent<ParticleSystem>().Play();
    }

    private void desactivarHumo() {
        transform.GetChild(3).GetComponent<ParticleSystem>().Stop();
        transform.GetChild(4).GetComponent<ParticleSystem>().Stop();
    }
}