using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesGenerator : MonoBehaviour {

    [SerializeField]
    private float instanceRate = 2f;
    [SerializeField]
    private int instanceAmount = 8;
    [SerializeField]
    private float instanceDelay = 0.5f;
    [SerializeField]
    private GameObject meteoro;
    [SerializeField]
    private GameObject agujero;
    [SerializeField]
    private GameObject robot;
    [SerializeField]
    private GameObject roca;
    [SerializeField]
    private GameObject satelite1;
    [SerializeField]
    private GameObject satelite2;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject escudo;    
    private float timeMisilLoad = 1f;
    [SerializeField]
    private Vector2 yRange;
    private bool generar = true;
    private BoxCollider2D delimiter;
    int x = 0;

    void Start() {
        Time.timeScale = 1;
        delimiter = GetComponent<BoxCollider2D>();
        delimiter.enabled = false;
        StartCoroutine(Meteoros());
        x = 5;
    }

    void Update () {
        if (generar) {
            timeMisilLoad += Time.deltaTime;

            int ale = Random.Range(0, 7);

            if (((int)timeMisilLoad % x == 0) && (InfoPlayer.getShield() != 2) && (ale == 1)) {
                Instantiate(escudo, new Vector3(21, Random.Range(yRange.x, yRange.y), 0), escudo.transform.rotation);
                if (x != 5){
                    timeMisilLoad = 1f;
                }
                x = 15;
            }

            if (((int)timeMisilLoad % 11 == 0) && (InfoPlayer.getMode() == 1)) {
                Instantiate(agujero, new Vector3(21, Random.Range(yRange.x + 3, yRange.y - 3), 0), agujero.transform.rotation);
                timeMisilLoad += 1f;
            }
        }
        if (Input.GetKeyDown("p")) {
            pausar();
        }
        
    }

    public void pausar(){
        if(Time.timeScale == 1){    //si la velocidad es 1
            Time.timeScale = 0;    //que la velocidad del juego sea 0
            panel.SetActive(true);
            PlayerPrefs.SetInt("onPause", 1);
        } else if(Time.timeScale == 0) {   // si la velocidad es 0
            panel.SetActive(false);
            Time.timeScale = 1;    // que la velocidad del juego regrese a 1
            PlayerPrefs.SetInt("onPause", 0);
        }
    }

    IEnumerator Meteoros() {
        GameObject[] obstaculos = { roca, roca, robot, meteoro, meteoro, satelite2, meteoro, meteoro, roca, meteoro, satelite1, roca, meteoro, roca, roca, meteoro};
        int size = obstaculos.Length;                

        while (true) {
            
            for (int i = 0; i < instanceAmount; i++) {
                yield return new WaitForSeconds(instanceDelay);
                GameObject ob = obstaculos[Random.Range(0, size)];
                Instantiate(ob, new Vector3(21, Random.Range(yRange.x, yRange.y), 0), ob.transform.rotation);
            }

            yield return new WaitForSeconds(instanceRate);
            
        }
        
    }

    public int getScoreTime(){
        return PlayerPrefs.GetInt("MaxTime", 0);
    }

    public void saveScoreTime(int actual){
        PlayerPrefs.SetInt("MaxTime", actual);
    }

    public int getScoreShoot(){
        return PlayerPrefs.GetInt("MaxShoot", 0);
    }

    public void saveScoreShoot(int actual){
        PlayerPrefs.SetInt("MaxShoot", actual);
    }

    public void switchGenerator() {
        delimiter.enabled = generar;
        generar = !generar;        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Obstaculo")) {
            Destroy(collision.gameObject);
        }
    }

}