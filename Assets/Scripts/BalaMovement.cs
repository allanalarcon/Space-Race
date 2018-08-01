using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovement : MonoBehaviour {

    public float velocidad = 20f;
    public float timeLife = 4f;

    // Use this for initialization
    void Start() {
        Destroy(gameObject, timeLife);
    }

    // Update is called once per frame
    void Update() {
        transform.position += transform.up * velocidad * Time.deltaTime;
    }
}
