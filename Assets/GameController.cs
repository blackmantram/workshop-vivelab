using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject cookie;
	private GameObject activeCookie;
	private List<Vector3> spawnPoints =new List<Vector3>(){
		new Vector3(-14, 3, 14),
		new Vector3(14, 3, 14),
		new Vector3(14, 3, -14)
	};

	void Start () {
		StartCoroutine(SpawnCookie(2.0F));
	}

	IEnumerator SpawnCookie(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		activeCookie = Instantiate(cookie);
		activeCookie.transform.position = spawnPoints[Random.Range(0, spawnPoints.Count)];
		StartCoroutine(RemoveCookie(2.0F));
	}

	IEnumerator RemoveCookie(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy(activeCookie);
		StartCoroutine(SpawnCookie(2.0F));
	}
}