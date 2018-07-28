using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour {
    
	Rigidbody2D rb;
    Animator anim;
    Vector2 Mov;
	public float Velocidad = 8f;
    private float angle = 3f;
    private int dir = 0;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        bool bup = Input.GetKey(KeyCode.UpArrow);
        bool bdown = Input.GetKey(KeyCode.DownArrow);
        Mov = new Vector2(Input.GetAxis("Horizontal"),
                          Input.GetAxis("Vertical"));
        anim.SetBool("disparando", Input.GetKey(KeyCode.Space));
        if (bup) {
            dir = 1;
        } else if (bdown) {
            dir = -1;
        } else {
            dir = 0;
        }
	}

    void FixedUpdate() {        

        rb.MovePosition(rb.position + Mov * Velocidad * Time.deltaTime);
        rb.MoveRotation(angle*dir);
    }
    

}