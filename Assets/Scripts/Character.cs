using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public GameSettings settings;

	public Material normalMaterial;
	public Material speedUpMaterial;

	private Rigidbody rigidBody;
	private float speedBoost = 0f;

	public void SpeedUp() {
		speedBoost = settings.speedBoost;
		GetComponent<Renderer>().material = speedUpMaterial;
		StartCoroutine(NormalizeSpeed());
	}

	private void Start() {
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.freezeRotation = true;
	}

	private void FixedUpdate (){
		Move();
	}

	private void Move()
	{
		Vector3 pos = transform.position;
		MoveAxis((int)Input.GetAxisRaw("Horizontal"), ref pos.x);
		MoveAxis((int)Input.GetAxisRaw("Vertical"), ref pos.z);
		transform.position = pos;
	}

	private void MoveAxis(int movement, ref float currentPosition)
	{
		currentPosition = currentPosition + (0.1f * (settings.speed + speedBoost) * movement);
	}

	private IEnumerator NormalizeSpeed()
	{
		yield return new WaitForSeconds(settings.speedBoostDuration);
		speedBoost = 0;
		GetComponent<Renderer>().material = normalMaterial;
	}
}
