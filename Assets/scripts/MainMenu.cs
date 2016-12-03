using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
    //Klikom na gumb počinje nivo
   public void StartLevel()
    {
        SceneManager.LoadScene("zavrsni");   
    }
    //klikom na gumb izlazi se iz igre
     public void Exit()
    {
        Application.Quit();
    }
    //pritiskom na gumb restarta se igra
    public void RestartGame()
    {
        SceneManager.LoadScene("zavrsni");
    }
}
