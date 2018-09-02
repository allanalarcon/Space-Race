using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour {

    Animator vida;
    Animator escudo;
    UnityEngine.UI.Text score;
    UnityEngine.UI.Text best;
    public GameObject nave;
    Player player;

	// Use this for initialization
	void Start () {
        vida = transform.GetChild(1).GetComponent<Animator>();
        escudo = transform.GetChild(2).GetComponent<Animator>();
        score = transform.GetChild(3).GetComponent<UnityEngine.UI.Text>();
        best = transform.GetChild(4).GetComponent<UnityEngine.UI.Text>();
        player = nave.GetComponent<Player>();  

        if (InfoPlayer.getMode() == 2){
            best.text = "Best: " + getScoreShoot().ToString();
        }
        else if (InfoPlayer.getMode() == 3){
            best.text = "Best: " + getScoreTime().ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
        vida.SetInteger("lifes", player.getLifes());
        escudo.SetInteger("ShieldPower", player.getShieldPower());
        score.text = ""+(int)player.getScore();

        if (InfoPlayer.getMode() == 2){
            if ((int)player.getScore() >= getScoreShoot()){
                best.text = "Best: " + score.text;
                saveScoreShoot((int)player.getScore());
            }
        }
        else if (InfoPlayer.getMode() == 3){
            if ((int)player.getScore() >= getScoreTime()){
                best.text = "Best: " + score.text;
                saveScoreTime((int)player.getScore());
            }
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
