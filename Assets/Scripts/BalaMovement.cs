using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovement : MonoBehaviour {

    public float velocidad = 20f;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.up * velocidad * Time.deltaTime;
    }
}
