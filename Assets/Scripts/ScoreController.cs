using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

    public Text scoreText;
	public Text finishMessage;

    private float score = 0f;

    void Start () {
		UpdateScore();
		SaveScore();
    }

    public void IncreaseScore(float points) {
		score = score + points;
        UpdateScore();
		SaveScore();
    }

	public void showFinishMessage() {
		finishMessage.gameObject.SetActive(true);
	}

	void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    void SaveScore() {
		Data data = new Data();
		data.lastScore = score;
        DataPersistent.Save(data);
    }
}
