using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    AudioSource sound;
    public GameObject animacion;

	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")) {
            // Animación de transición
            GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();

            //el sonido debería ir en la animacion y no en el agujero
            sound.Play();

            //Destruye los obstaculos
            Destroy(GameObject.Find("Roca(Clone)"));
            Destroy(GameObject.Find("Robot(Clone)"));
            Destroy(GameObject.Find("Satelite1(Clone)"));
            Destroy(GameObject.Find("Satelite2(Clone)"));

            //mueve la nave a un lugar donde no se vea
            GameObject.Find("Lanzadera").transform.Translate(-20, 11, 0);

            //destruye el agujero
            Destroy(GameObject.Find("BlackHoleIn(Clone)"));

            //inicia la animacion
            Instantiate(animacion, new Vector3(0, 0, 8), animacion.transform.rotation);
            collision.gameObject.GetComponent<Player>().setScore(Random.Range(-15, 15));

        } else if (collision.CompareTag("Finish")){
            Destroy(gameObject);
        }
        else {
            Destroy(collision.gameObject);
        }
    }

    public void desactivarAnimacion() {

        //destruye la animacion
        Destroy(animacion);

        //donde la nave aparecera despues de la animación
        GameObject.Find("Lanzadera").transform.Translate(-10, -1, 0);

        GameObject.Find("GameController").GetComponent<ObstaclesGenerator>().switchGenerator();
        sound.Play();
        

        //Escupir nave

    }
}
