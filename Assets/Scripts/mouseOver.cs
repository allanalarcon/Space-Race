﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOver : MonoBehaviour {

    AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}

    void OnMouseEnter() {
        sound.Play();        
    }
}
