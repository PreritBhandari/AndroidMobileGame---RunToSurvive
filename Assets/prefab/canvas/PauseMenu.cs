using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;


    public GameObject pauseMenuUI;

    
    public GameObject pauseButtonUI;

    public AudioSource pauseAudio;


    void Start () 
    {
    pauseMenuUI.SetActive (false);
    
    pauseButtonUI.SetActive (true);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {

                Resume();
            }else
            {
                Pause();
            }
        

        }

    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
        pauseButtonUI.SetActive(true);


    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;
        pauseButtonUI.SetActive(false);


    }


    public void LoadMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Menu");

    }

    
    public void QuitMenu()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
        
    }

    public void pausedAudio()
    {
        pauseAudio.Play ();
    }

}
