using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    Animator vida;
    Animator escudo;
    Text score;
    Text best;
    public GameObject nave;
    Player player;
    private int maxValue = 90; // Tiempo de duración del nivel en segundos
    Slider barra;
    Slider weapon;

	// Use this for initialization
	void Start () {
        vida = transform.GetChild(1).GetComponent<Animator>();
        escudo = transform.GetChild(2).GetComponent<Animator>();
        score = transform.GetChild(3).GetComponent<Text>();
        weapon = transform.GetChild(5).GetComponent<Slider>();
        
        player = nave.GetComponent<Player>();  
        if (InfoPlayer.getMode() == 1) {
            barra = transform.GetChild(4).GetComponent<Slider>();
        } else {
            best = transform.GetChild(4).GetComponent<Text>();
            if (InfoPlayer.getMode() == 2) {
                best.text = "Best: " + getScoreShoot().ToString();
            } else if (InfoPlayer.getMode() == 3) {
                best.text = "Best: " + getScoreTime().ToString();
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        vida.SetInteger("lifes", player.getLifes());
        escudo.SetInteger("ShieldPower", player.getShieldPower());

        if (Input.GetKeyDown(KeyCode.Space)) {            
            weapon.value += weapon.value < 1? 0.03f : 0f;
        } else {
            weapon.value -= weapon.value > 0 ? 0.001f : 0f;
        }        

        
        if (InfoPlayer.getMode() == 1) {
            updateValue(player.getScore());
        } else {
            score.text = "" + (int)player.getScore();
            if (InfoPlayer.getMode() == 2) {
                if ((int)player.getScore() >= getScoreShoot()) {
                    best.text = "Best: " + score.text;
                    saveScoreShoot((int)player.getScore());
                }
            } else if (InfoPlayer.getMode() == 3) {
                if ((int)player.getScore() >= getScoreTime()) {
                    best.text = "Best: " + score.text;
                    saveScoreTime((int)player.getScore());
                }
            }
        }
        
	}

    public void updateValue(float value) {
        float progress = value / maxValue;
        int porcentaje = (int)(progress * 100);
        if (porcentaje <= 100) {
            barra.value = progress;
            score.text = porcentaje + " %";
        } else {
            // Siguiente nivel - Cambiar escena level 2
            player.levelComplete();
            SceneManager.LoadScene("LevelUp");
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
