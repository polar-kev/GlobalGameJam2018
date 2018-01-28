using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	static MusicController instance = null;


	void Start ()
	{
		//Singleton pattern- if music is already playing, destroy the new music player
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self destruting");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
