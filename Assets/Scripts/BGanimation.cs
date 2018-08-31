using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGanimation : MonoBehaviour {

	Transform tr;  
    public float maxScale = 2.45f;
    public float minScale = 1.2f;
    private float escala, x, y, z;
    public float factorEscala;
    public float factorRotacion;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
        x = tr.localScale.x;
        y = tr.localScale.y;
        z = tr.localScale.z;        
	}
	
	// Update is called once per frame
	void Update () {
        escala = factorEscala * Time.deltaTime;
        if (x <= maxScale && x >= minScale)
        {
            x += escala;
            y += escala;
            z += escala;
        }

        tr.localScale = new Vector3(x, y, z);        
        tr.Rotate(Vector3.forward, factorRotacion);
	}
}
