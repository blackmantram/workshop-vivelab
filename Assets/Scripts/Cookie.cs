using UnityEngine;
using System;
using System.Collections;

public class Cookie : MonoBehaviour {

	public Action touched;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Character"))
		{
			gameObject.SetActive(false);
			if (touched != null)
				touched();
		}
	}
}
