using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityEngine.UI.Text score = GetComponent<UnityEngine.UI.Text>();
        score.text = "" + (int)InfoPlayer.score;
    }
	

}
