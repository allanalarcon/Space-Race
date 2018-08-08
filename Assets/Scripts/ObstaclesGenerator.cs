using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour {
	
	public GameObject meteoro;    
    public GameObject lluvia;
    public GameObject agujero;
    public GameObject robot;
    public GameObject roca;
    public GameObject satelite1;
    public GameObject satelite2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if (Input.GetKeyDown(KeyCode.Z)){
			Instantiate(meteoro, new Vector3(Random.Range(20, 25), Random.Range(-7, 7), 0), meteoro.transform.rotation);
		}

        if (Input.GetKeyDown(KeyCode.X)) {
            Instantiate(lluvia, new Vector3(Random.Range(0,15),Random.Range(8,11),0), lluvia.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            Instantiate(agujero, new Vector3(Random.Range(20, 25), Random.Range(-4, 4), 0), agujero.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.V)) {
            Instantiate(robot, new Vector3(Random.Range(20, 25), Random.Range(-7, 7), 0), robot.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            Instantiate(roca, new Vector3(Random.Range(20, 25), Random.Range(-7, 7), 0), roca.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            Instantiate(satelite1, new Vector3(Random.Range(20, 25), Random.Range(-7, 7), 0), satelite1.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            Instantiate(satelite2, new Vector3(Random.Range(20, 25), Random.Range(-7, 7), 0), satelite2.transform.rotation);
        }
    }
}
