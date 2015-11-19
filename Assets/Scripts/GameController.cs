using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject cookie;
	public Character character;
	public GameSettings settings;
	public ScoreController score;

	private SpeedCookie activeCookie;
	private int cookieCount;
	private int grabbedCookies;

	private bool isGameRunning = true;

	private void Start () {
		ScheduleCookieSpawn();
		InitCookies();
	}

	private void Update() {
		if (grabbedCookies == cookieCount)
			EndGame();
	}

	private void EndGame() {
		isGameRunning = false;
		if (activeCookie != null)
			Destroy(activeCookie.gameObject);
		score.showFinishMessage();
		StartCoroutine(ScheduleMenuLoad());
	}

	private void ScheduleCookieSpawn() {
		StartCoroutine(SpawnCookie(settings.cookieSpawnTime));
	}

	private IEnumerator SpawnCookie(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (isGameRunning)
		{
			activeCookie = Instantiate(cookie).GetComponent<SpeedCookie>();
			activeCookie.touched += HandleSpeedCookieTouched;
			int spawnPointIndex = Random.Range(0, settings.cookieSpawnPoints.Count);
			activeCookie.transform.position = settings.cookieSpawnPoints[spawnPointIndex];
			StartCoroutine(RemoveCookie(settings.cookieTimeLimit));
		}
	}

	private IEnumerator RemoveCookie(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (isGameRunning)
		{
			Destroy(activeCookie.gameObject);
			activeCookie = null;
			ScheduleCookieSpawn();
		}
	}

	private IEnumerator ScheduleMenuLoad() {
		yield return new WaitForSeconds(5f);
		Application.LoadLevel("menu");
	}

	private void HandleSpeedCookieTouched() {
		character.SpeedUp();
		score.IncreaseScore(settings.speedUpCookieScore);
		activeCookie.touched -= HandleCookieTouched;
	}

	private void InitCookies() {
		Cookie[] cookies = FindObjectsOfType(typeof(Cookie)) as Cookie[];
		cookieCount = cookies.Length;
		foreach(Cookie cookie in cookies)
		{
			cookie.touched += HandleCookieTouched;
		}
	}

	private void HandleCookieTouched() {
		score.IncreaseScore(settings.cookieScore);
		grabbedCookies++;
	}
}