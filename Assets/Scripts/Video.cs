using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour {

	public GameObject video;
	private float timeMisilLoad = 1f;

	public GameObject loadingpanel;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		timeMisilLoad = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		timeMisilLoad += Time.deltaTime;
		//Debug.Log(video.GetComponent<VideoPlayer>().clip.ToString());
		//Debug.Log(timeMisilLoad);
		
		if (video.GetComponent<VideoPlayer>().clip.ToString() == "Intro Juego (UnityEngine.VideoClip)"){
			if (6 < timeMisilLoad){
				if (!video.GetComponent<VideoPlayer>().isPlaying){
					SceneManager.LoadScene("VideoLevel1A");
				}
			}
		}

		else if (video.GetComponent<VideoPlayer>().clip.ToString() == "Nivel 1 Video (UnityEngine.VideoClip)"){
			if (6 < timeMisilLoad){
				if (!video.GetComponent<VideoPlayer>().isPlaying){
					InfoPlayer.setMode(1);
					loadingpanel.SetActive(true);
				}
			}
		} 
        
        else if (video.GetComponent<VideoPlayer>().clip.ToString() == "Nivel 1 Video Aterrizaje (UnityEngine.VideoClip)") {
            if (6 < timeMisilLoad) {
                if (!video.GetComponent<VideoPlayer>().isPlaying) {
                    SceneManager.LoadScene("LevelUp");
                }
            }
        }
        
        else if (video.GetComponent<VideoPlayer>().clip.ToString() == "Nivel 2 Video (UnityEngine.VideoClip)"){
			if (6 < timeMisilLoad){
				if (!video.GetComponent<VideoPlayer>().isPlaying){
					InfoPlayer.setMode(1);
					loadingpanel.SetActive(true);
				}
			}
		}

		else if (video.GetComponent<VideoPlayer>().clip.ToString() == "Nivel 2 Video Aterrizaje (UnityEngine.VideoClip)"){
			if (6 < timeMisilLoad){
				if (!video.GetComponent<VideoPlayer>().isPlaying){
					SceneManager.LoadScene("End");
				}
			}
		}
		
	}
}
