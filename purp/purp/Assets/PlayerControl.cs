using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 1;
	new Event e;
	Animator[] anim = new Animator[2];
	public int Dir = 0;
	int DirHash = Animator.StringToHash("Direction");
	int WalkHash = Animator.StringToHash("Walking");
	int AttackHash = Animator.StringToHash("Axe_Swing");
	bool ifCheck = false;

	void Mora_Move() {

		Vector3 vector = Vector3.down;

		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
			Dir = 1;
			vector = Vector3.left;
		} else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			Dir = 2;
			vector = Vector3.right;
		} else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			Dir = 3;
			vector = Vector3.up;
		} else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			Dir = 0;
			vector = Vector3.down;
		}

		/*
		if (Dir == 0) {
			vector = Vector3.C;
		} else if (Dir == 1) {
			vector = Vector3.left;
		} else if (Dir == 2) {
			vector = Vector3.right;
		} else if (Dir == 3) {
			vector = Vector3.up;
		}*/

		anim[0].SetInteger(DirHash, Dir);

		if (Dir_Pressed()) {
			transform.Translate(vector * Time.deltaTime * speed);
		}

	}

	void Axe_Attack() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			ifCheck = true;
			anim[1].SetBool(AttackHash, ifCheck);
		}
		if (ifCheck) {
			ifCheck = false;
			anim[1].SetBool(AttackHash, ifCheck);
		}
	}

	public bool Dir_Pressed() {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) {
			return true;
		} else {
			return false;
		}

	}

	private void OnGUI() {
	}

	// Use this for initialization
	void Start () {
		anim = GetComponentsInChildren<Animator>();
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		anim[0].SetBool(WalkHash, Dir_Pressed());
		Mora_Move();
		Axe_Attack();

	}
}

