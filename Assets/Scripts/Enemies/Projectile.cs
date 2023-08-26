using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
