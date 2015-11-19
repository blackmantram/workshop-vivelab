using UnityEngine;
using System.Collections;

public class Cookie : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Character"))
			gameObject.SetActive(false);
	}
}
