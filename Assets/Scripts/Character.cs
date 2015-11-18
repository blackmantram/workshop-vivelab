using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float speed = 2;

	private Rigidbody rigidBody;
	void Start() {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.freezeRotation = true;
	}

	void FixedUpdate (){
		int horizontalMovement = (int)Input.GetAxisRaw("Horizontal");
		int verticalMovement = (int)Input.GetAxisRaw("Vertical");

		Transform transform = this.transform;
		Vector3 pos = transform.position;
		if (horizontalMovement != 0)
		{
			pos.x = pos.x + (0.1f * speed * horizontalMovement);
		}
		if (verticalMovement != 0)
		{
			pos.z = pos.z + (0.1f * speed * verticalMovement);
		}
		transform.position = pos;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Cookie"))
			other.gameObject.SetActive(false);
	}
}
