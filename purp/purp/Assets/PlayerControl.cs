using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 1;
	Animator[] anim = new Animator[2];
	public int Dir = 0;
	int DirHash = Animator.StringToHash("Direction");
	int WalkHash = Animator.StringToHash("Walking");
	int DashHash = Animator.StringToHash("Dashing");
	int AttackHash = Animator.StringToHash("Axe_Swing");
	bool ifCheck = false;
	public Dashing GetDashing;
	public int DashSpeed = 5;
	Vector3 dashVector = Vector3.down;


	void Walk(Vector3 vector) {
		transform.Translate(vector * Time.deltaTime * speed);
	}


	void Mora_Move() {

		Vector3 vector = Vector3.down;
		if (!GetDashing.IsDashing) {
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



			anim[0].SetBool(WalkHash, Dir_Pressed());
			anim[0].SetBool(DashHash, false);
			anim[0].SetInteger(DirHash, Dir);
			if (Input.GetButtonDown("Fire3")) {
				anim[0].SetBool(DashHash, true);
				anim[0].SetBool(WalkHash, false);
				dashVector = vector;
				transform.Translate(vector * Time.deltaTime * speed);
			} else {
				if (Dir_Pressed()) {
					Walk(vector);
				}
			}
		} else {
			if (Dir == 0) {
				vector = Vector3.down;
			} else if (Dir == 1) {
				vector = Vector3.left;
			} else if (Dir == 2) {
				vector = Vector3.right;
			} else if (Dir == 3) {
				vector = Vector3.up;
			}
			transform.Translate(vector * Time.deltaTime * speed * DashSpeed);
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
	void Start() {
		anim = GetComponentsInChildren<Animator>();
	}


	// Update is called once per frame
	void FixedUpdate() {
		Mora_Move();
		Axe_Attack();


	}
}

