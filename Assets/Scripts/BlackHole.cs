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

            collision.gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            collision.gameObject.transform.position = new Vector3(-10f, 10f, 0f);
            collision.gameObject.GetComponent<ShipMovement>().desactivarHumo();

            GetComponent<CapsuleCollider2D>().enabled = false;
            // Animación de transición
            collision.gameObject.GetComponent<ShipMovement>().blockUnblockShoot();
            GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();

            //inicia la animacion            
            collision.gameObject.GetComponent<TurnAnimationHole>().activarAnimacion();          
            //Instantiate(animacion, new Vector3(0, 0, 8), animacion.transform.rotation);

            collision.gameObject.GetComponent<Player>().setScore(Random.Range(-15, 15));
            Destroy(gameObject);

        } else if (collision.CompareTag("Finish")){
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Pared")){
            Destroy(collision.gameObject);
        }
    }
    
}
