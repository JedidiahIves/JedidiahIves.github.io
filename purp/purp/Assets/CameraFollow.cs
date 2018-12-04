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
		} else if (camVector.y > (transform.position.y + margin[0])) {
			moddedVector.y++;
		}

		if (camVector.x < (transform.position.x - margin[1])) {
			moddedVector.x--;
		} else if (camVector.x > (transform.position.x + margin[1])) {
			moddedVector.x++;
		}

		if (!(moddedVector == transform.position)) {
			transform.position = Vector3.Lerp(transform.position, moddedVector, Time.deltaTime * smoothFactor);
		}
		//	transform.position = camVector;
	}
}
