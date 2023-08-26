using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject player;

    public float speedUpPowerUpValue = 600;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public enum powerUpType
    {
        speedUp,

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>()._moveSpeed = speedUpPowerUpValue;
            Destroy(gameObject);
        }
    }
}
