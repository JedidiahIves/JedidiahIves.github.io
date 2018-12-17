using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioSource[] audioData = new AudioSource[3];

	bool alternate = true;
	int Clip = 1;

	private void Start() {
		audioData = GetComponentsInChildren<AudioSource>();
	}

	public void playClip(int WhichSound) {
		if (WhichSound == 0 || WhichSound == 1) {
			Clip = (Clip == 0) ? 1 : 0;
		} else {
			Clip = WhichSound;
		}
		if (Clip >= audioData.Length) {
			Clip = audioData.Length - 1;
		}
		audioData[Clip].Play();
	}
}
