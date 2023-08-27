using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireAntBehaviour : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Transform launchOffset;

    private void Start()
    {
        InvokeRepeating("InstantiateProjectile", 1f, 5f);
    }

    private void Update()
    {
        

    }

    private void InstantiateProjectile()
    {
        Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
        GameObject.FindWithTag("FireBall").GetComponent<AudioSource>().Play();
    }

}
