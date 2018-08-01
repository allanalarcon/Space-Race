using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroScript : MonoBehaviour {

	public Transform Tmeteoro;
	public GameObject meteoro;
    public Transform Tlluvia;
    public GameObject lluvia;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			Instantiate(meteoro, Tmeteoro.position, meteoro.transform.rotation);
		}

        if (Input.GetKeyDown(KeyCode.X)) {
            Instantiate(lluvia, Tlluvia.position, lluvia.transform.rotation);
        }
	}
}
