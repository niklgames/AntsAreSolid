using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;
    public int winScore = 100;

    private int score = 0;
    

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddPoints_Ant_1()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void AddPoints_FireAnt()
    {
        score += 2;
        scoreText.text = score.ToString();
    }

    private void Update()
    {
        CompleteLevel();
    }

    public void CompleteLevel()
    {
        if (score >= winScore)
        {
            if (SceneManager.GetActiveScene().name == "Level_3")
            {
                SceneManager.LoadScene("YouWin");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
