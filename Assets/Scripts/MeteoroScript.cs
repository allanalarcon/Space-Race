using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroScript : MonoBehaviour {

	public Transform Tmeteoro;
	public GameObject meteoro;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			Instantiate(meteoro, Tmeteoro.position, meteoro.transform.rotation);
		}
	}
}
