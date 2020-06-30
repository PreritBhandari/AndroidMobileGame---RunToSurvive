using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDownTimer : MonoBehaviour

{

    private float score =0.0f;

    private int difficultyLevel =1;
    private int maxDifficultyLevel =10;
    private int scoreToNextLevel=10;

    private bool isDead =false;
    public Text scoreText;
    public DeathMenu deathMenu;





    // Update is called once per frame

    void Update()
    {   
        if (isDead)
        {
            return;
        } 
        if (score>=scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;
        scoreText.text=((int)score).ToString();


        // if(score<1000f){scoreText.color = Color.black;}
        // if(score>1000f){scoreText.color = Color.red;}

    }


    void LevelUp()
    {   
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *=2;
        difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
        Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore")<score)
        {
           PlayerPrefs.SetFloat("Highscore",score); 
        }
                
        deathMenu.ToggleEndMenu (score);
    }




    
        
}