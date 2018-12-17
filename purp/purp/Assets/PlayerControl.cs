using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 1;
	public Animator[] anim = new Animator[2];
	public int Dir = 0;
	int DirHash = Animator.StringToHash("Direction");
	int WalkHash = Animator.StringToHash("Walking");
	int DashHash = Animator.StringToHash("Dashing");
	int AttackHash = Animator.StringToHash("AttackNum");
	bool ifCheck = false;
	public Dashing GetDashing;
	public int DashSpeed = 5;
	public float deadzone = .05F;
	Vector3 dashVector = Vector3.down;
	public int AttackNum;

	void Walk(Vector3 vector) {
		transform.Translate(vector * Time.deltaTime * speed);
	}


	void Mora_Move() {

		Vector3 vector = Vector3.down;
		if (!GetDashing.IsDashing) {
			if (Input.GetAxis("Horizontal") < -deadzone) {
				Dir = 1;
				vector = Vector3.left;
			} else if (Input.GetAxis("Horizontal") > deadzone) {
				Dir = 2;
				vector = Vector3.right;
			} else if (Input.GetAxis("Vertical") > deadzone) {
				Dir = 3;
				vector = Vector3.up;
			} else if (Input.GetAxis("Vertical") < -deadzone) {
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
			//Debug.Log("H:" + Input.GetAxis("Horizontal") + "V:" + Input.GetAxis("Vertical")) ;


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

			if(Input.GetButtonDown("Attack")) {
				Base_Atack();
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


/*
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
*/
	public bool Dir_Pressed() {
		if (Input.GetAxis("Horizontal") < -deadzone || Input.GetAxis("Horizontal") > deadzone || Input.GetAxis("Vertical") > deadzone || Input.GetAxis("Vertical") < -deadzone) {
			return true;
		} else {
			return false;
		}

	}

	void Base_Atack() {

		AttackNum = Dir;
		anim[1].SetInteger(AttackHash, AttackNum);
	}

	public void Attack_Clear() {
		AttackNum = 0;
		anim[1].SetInteger(AttackHash, 0);
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


	}
}

