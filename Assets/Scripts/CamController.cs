using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    Camera cam;
    public float size = 7f;
    private float defaultSize = 5f;
    private bool activated = false;
    private float zoom;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        zoom = defaultSize;
        if (Input.GetKeyDown(KeyCode.C)) {
            if (!activated) {
                zoom = size;
                activated = true;
            } else {
                //zoom = defaultSize;
                //activated = false;
            }
        }

        cam.orthographicSize = zoom;
    }

    private void FixedUpdate() {
        
    }
}
