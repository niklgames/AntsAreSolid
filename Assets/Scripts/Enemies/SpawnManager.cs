using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;

    public GameObject antPrefab;
    public int numberOfAnts = 100;

    private List<GameObject> ants = new List<GameObject>();

    private void Start()
    {
        InstantiateAnts();
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        GameObject player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
    }

    private void InstantiateAnts()
    {
        for (int i = 0; i < numberOfAnts; i++)
        {
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            GameObject ant = Instantiate(antPrefab, Random.insideUnitCircle * 10, randomRotation);
            ants.Add(ant);
        }
    }
}
