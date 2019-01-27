using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	void Awake() {
		Debug.Log("Music player Awake " + GetInstanceID());
		if (instance != null) {
    		Destroy(gameObject);
    		//print("Duplicate music player self-destructing!");
    	} else {
    		instance = this;
            DontDestroyOnLoad(gameObject);
    	}
	}

    void Start() {
		//Debug.Log("Music player Start " + GetInstanceID());
    }

    void Update() {
        
    }

    public IEnumerator FadeOut(float FadeTime) {
        AudioSource audioSource = instance.GetComponent<AudioSource>();

        float startVolume = audioSource.volume;

        Debug.Log("fadee...");
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
