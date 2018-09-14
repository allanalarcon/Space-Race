using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {


	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {
            GetComponent<CapsuleCollider2D>().enabled = false;
            // Animación de transición
            GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();

            //inicia la animacion            
            collision.gameObject.GetComponent<TurnAnimationHole>().activarAnimacion();          
            //Instantiate(animacion, new Vector3(0, 0, 8), animacion.transform.rotation);

            collision.gameObject.GetComponent<Player>().setScore(Random.Range(-15, 15));
            collision.gameObject.GetComponent<ShipMovement>().blockUnblockShoot();

        } else if (collision.CompareTag("Finish")){
            Destroy(gameObject);
        }
        else {
            Destroy(collision.gameObject);
        }
    }
    
}
