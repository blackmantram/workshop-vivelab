using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LastScoreController : MonoBehaviour {

    void Start () {
        LoadLastScore();
    }

    void LoadLastScore() {
        DataPersistent.Load();
		Text lastScoreText = GetComponent<Text>();
		lastScoreText.text = "Your last score was : " + DataPersistent.data.lastScore;
    }
	
}
