using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerEat : MonoBehaviour
{
    

    public float startingSatiety = 1.0f; // 100%
    public float satietyDecreaseRate = 0.1f; // Rate of decrease per second
    public float satietyIncreaseAmount = 0.2f; // Amount increased per ant eaten

    public float currentSatiety;

    public Slider satietySlider;

    private void Start()
    {
        currentSatiety = startingSatiety;
    }

    private void Update()
    {
        // Decrease satiety over time
        currentSatiety -= satietyDecreaseRate * Time.deltaTime;

        // Clamp satiety to [0, 1] range
        currentSatiety = Mathf.Clamp01(currentSatiety);
        
        satietySlider.value = currentSatiety;

        if (satietySlider.value <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void EatAnt()
    {
        // Increase satiety by the specified amount
        currentSatiety = Mathf.Min(1.0f, currentSatiety + satietyIncreaseAmount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ant_1"))
        {
            GameObject.FindWithTag("Crunch").GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            ScoreManager.instance.AddPoints_Ant_1();
            EatAnt();
        }

        if (collision.gameObject.CompareTag("FireAnt"))
        {
            GameObject.FindWithTag("Crunch").GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            ScoreManager.instance.AddPoints_FireAnt();
        }
    }
}