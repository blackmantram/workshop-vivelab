using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public void StartGame()
    {
        Application.LoadLevel("maze");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
