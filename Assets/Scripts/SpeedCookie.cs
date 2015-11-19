using UnityEngine;
using System.Collections;

public class SpeedCookie : Cookie {
	private void Update () {
		transform.Rotate(Vector3.right, 4f);
	}
}
