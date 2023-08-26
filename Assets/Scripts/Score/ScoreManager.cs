using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;

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

}
