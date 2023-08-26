using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
