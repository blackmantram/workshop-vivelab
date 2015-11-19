using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject cookie;
	public Character character;
	public GameSettings settings;

	private GameObject activeCookie;

	void Start () {
		ScheduleCookieSpawn();
	}

	private void ScheduleCookieSpawn() {
		StartCoroutine(SpawnCookie(settings.cookieSpawnTime));
	}

	IEnumerator SpawnCookie(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		activeCookie = Instantiate(cookie);
		activeCookie.GetComponent<Cookie>().touched += HandleCookieTouched;
		int spawnPointIndex = Random.Range(0, settings.cookieSpawnPoints.Count);
		activeCookie.transform.position = settings.cookieSpawnPoints[spawnPointIndex];
		StartCoroutine(RemoveCookie(settings.cookieTimeLimit));
	}

	IEnumerator RemoveCookie(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		Destroy(activeCookie);
		ScheduleCookieSpawn();
	}

	private void HandleCookieTouched() {
		character.SpeedUp();
	}
}