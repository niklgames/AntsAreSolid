using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEat : MonoBehaviour
{
    [SerializeField] 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ant_1"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddPoints_Ant_1();
        }

        if (collision.gameObject.CompareTag("FireAnt"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddPoints_FireAnt();
        }
    }
}
