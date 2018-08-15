using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstaclesGenerator : MonoBehaviour {

    public float instanceRate = 2f;
    public int instanceAmount = 4;
    public float instanceDelay = 0.5f;
    public GameObject meteoro;
    public GameObject lluvia;
    public GameObject agujero;
    public GameObject robot;
    public GameObject roca;
    public GameObject satelite1;
    public GameObject satelite2;
    public Vector2 yRange;


    void Start() {
        StartCoroutine(Meteoros());
    }

    IEnumerator Meteoros() {
        GameObject[] obstaculos = { meteoro, robot, roca, satelite1, satelite2 };
        while (true) {

            for (int i = 0; i < instanceAmount; i++) {
                yield return new WaitForSeconds(instanceDelay);
                GameObject ob = obstaculos[Random.Range(0, 4)];
                Instantiate(ob, new Vector3(Random.Range(20, 25), Random.Range(yRange.x, yRange.y), 0), ob.transform.rotation);
            }

            yield return new WaitForSeconds(instanceRate);

        }
    }
}