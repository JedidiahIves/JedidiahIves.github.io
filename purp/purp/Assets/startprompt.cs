using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startprompt : MonoBehaviour {

	Text anykey_text;
	public Color OpaqueCream, TransparantCream;
	public float pingponged_float = 2;

	public void GameStart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


	private void Start() {

		anykey_text = GetComponent<Text>();
		OpaqueCream = anykey_text.color;
		TransparantCream = OpaqueCream;
		TransparantCream.a = .2f;
		pingponged_float = .5f;

	}

	void Update() {

		anykey_text.color = Color.Lerp(OpaqueCream, TransparantCream, Mathf.PingPong(Time.time * pingponged_float,1));

		if (Input.anyKeyDown) {
			if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1)) {
				return;
			} else {
				GameStart();
			}
		}


	}
}
