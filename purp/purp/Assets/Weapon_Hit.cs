using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Hit : MonoBehaviour {
	public int Score = 0;
	public PlayerControl PlayerController;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

	void Attack_Clear() {
		PlayerController.Attack_Clear();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log(collision.gameObject.name + " Hit!");
		// +
		if(collision.gameObject.tag == "Enemy") {
			Destroy(collision.gameObject);
			Score++;
		}


	}
}
