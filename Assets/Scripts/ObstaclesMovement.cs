using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesMovement : MonoBehaviour {

	public float velocidad = 15f;
    public float rotacion = 0f;
    public float timeLife = 4f;

    Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();        
        rb.angularVelocity = rotacion;
        Destroy(gameObject, timeLife);
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = Vector3.right * -velocidad;
        //transform.position -= transform.right * velocidad * Time.deltaTime;
        //transform.Rotate(Vector3.forward, rotacion);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Finish")) {
            Destroy(gameObject);
        }
    }
}
