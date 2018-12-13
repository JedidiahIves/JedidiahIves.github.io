using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour {

	public bool IsDashing = false;

	public void Dash(int DashingInt) {
		if (DashingInt == 1) {
			IsDashing = true;
		} else {
			IsDashing = false;
		}

	}
}
