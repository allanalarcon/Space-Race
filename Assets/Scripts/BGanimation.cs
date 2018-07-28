using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGanimation : MonoBehaviour {

	Transform tr;  
    private float maxScale = 2.45f;
    private float minScale = 1.2f;
    private float escala, x, y, z;

	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
        x = y = z = minScale;
	}
	
	// Update is called once per frame
	void Update () {
        escala = 0.03f * Time.deltaTime;
        if (x < maxScale)
        {
            x += escala;
            y += escala;
            z += escala;
        }

        tr.localScale = new Vector3(x, y, z);
	}
}
