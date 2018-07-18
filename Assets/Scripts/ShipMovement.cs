using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour {

	Rigidbody rb;
	public float Velocidad = 8f;
	public float delay;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 DireccionX = Input.GetAxis ("Horizontal") * Vector3.right;
		Vector3 DireccionZ = Input.GetAxis ("Vertical") * Vector3.forward;

		Vector3 Direccion = DireccionX + DireccionZ;
		Vector3 VectorVelocidad = Direccion * Velocidad;

		rb.velocity = VectorVelocidad;
	}
}