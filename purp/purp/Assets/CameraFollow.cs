using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	Vector3 camVector;
	public int[] margin = new int[2];

	public float smoothFactor = 2;



	// Use this for initialization
	void Start () {
		margin[0] = 2;
		margin[1] = 3;
	}

	// Update is called once per frame
	void LateUpdate () {


		camVector = player.transform.position;
		camVector.z = -10;
		Vector3 moddedVector = transform.position;
		if (camVector.y < (transform.position.y - margin[0] )) {
			moddedVector.y--;
			if (camVector.y < (transform.position.y - (margin[0]*2))) {
				smoothFactor = Mathf.Lerp(smoothFactor, Mathf.Abs(transform.position.y - (margin[0])) + 2, Time.deltaTime);
			} else {
				smoothFactor = Mathf.Lerp(smoothFactor, 2, Time.deltaTime);
			}
		} else if (camVector.y > (transform.position.y + margin[0])) {
			moddedVector.y++;
			if (camVector.y > (transform.position.y + (margin[0] * 2))) {
				smoothFactor = Mathf.Lerp(smoothFactor, Mathf.Abs(transform.position.y + (margin[0])) + 2, Time.deltaTime);
			} else {
				smoothFactor = Mathf.Lerp(smoothFactor, 2, Time.deltaTime);
			}
		}

		if (camVector.x < (transform.position.x - margin[1])) {
			moddedVector.x--;
			if (camVector.x < (transform.position.x - (margin[1] * 2))) {
				smoothFactor = Mathf.Lerp(smoothFactor, Mathf.Abs(transform.position.x - (margin[1])) + 2, Time.deltaTime);
			} else {
				smoothFactor = Mathf.Lerp(smoothFactor, 2, Time.deltaTime);
			}
		} else if (camVector.x > (transform.position.x + margin[1])) {
			moddedVector.x++;
			if (camVector.x > (transform.position.x + (margin[1] * 2))) {
				smoothFactor = Mathf.Lerp(smoothFactor, Mathf.Abs(transform.position.x + (margin[1])) + 2, Time.deltaTime);
			} else {
				smoothFactor = Mathf.Lerp(smoothFactor, 2, Time.deltaTime);
			}
		}

		if (!(moddedVector == transform.position)) {
			transform.position = Vector3.Lerp(transform.position, moddedVector, Time.deltaTime * smoothFactor);
		}
		//	transform.position = camVector;
	}
}
