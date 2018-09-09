using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesGenerator : MonoBehaviour {

    public float instanceRate = 2f;
    public int instanceAmount = 8;
    public float instanceDelay = 0.5f;
    public GameObject meteoro;
    public GameObject lluvia;
    public GameObject agujero;
    public GameObject robot;
    public GameObject roca;
    public GameObject satelite1;
    public GameObject satelite2;
    public GameObject panel;
    public GameObject escudo;
    private float timeMisilLoad = 1f;
    public Vector2 yRange;


    void Start() {
        Time.timeScale = 1;
        StartCoroutine(Meteoros());
    }

    void Update () {
        timeMisilLoad += Time.deltaTime;

        Debug.Log(timeMisilLoad);

        if ( ( (int)timeMisilLoad % 15 == 0) && (InfoPlayer.getShield() != 2) ){
            Instantiate(escudo, new Vector3(21, Random.Range(yRange.x, yRange.y), 0), escudo.transform.rotation);
            timeMisilLoad = 1f;
        }

        if (((int)timeMisilLoad % 10 == 0) && (InfoPlayer.getMode() == 1)){
            Instantiate(agujero, new Vector3(21, Random.Range(yRange.x+3, yRange.y-3), 0), agujero.transform.rotation);
            timeMisilLoad += 1f;
        }

        if(Input.GetKeyDown("p")){
            pausar();
        }
    }

    public void pausar(){
        if(Time.timeScale == 1){    //si la velocidad es 1
            Time.timeScale = 0;    //que la velocidad del juego sea 0
            panel.SetActive(true);
        } else if(Time.timeScale == 0) {   // si la velocidad es 0
            panel.SetActive(false);
            Time.timeScale = 1;    // que la velocidad del juego regrese a 1
        }
    }

    IEnumerator Meteoros() {
        GameObject[] obstaculos = { roca, robot, meteoro, meteoro, satelite2, meteoro, roca, meteoro, satelite1, meteoro, roca, roca};
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
}