using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{   
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text="Highscore : " + (int)PlayerPrefs.GetFloat("Highscore");
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Scene0-new");
    }
}
