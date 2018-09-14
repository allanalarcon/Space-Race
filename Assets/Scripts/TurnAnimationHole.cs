using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAnimationHole : MonoBehaviour {

    public GameObject AnimationHole;

	// Use this for initialization
	void Start () {
		
	}
	
    public void activarAnimacion() {
        AnimationHole.SetActive(true);
        
    }
    
}
