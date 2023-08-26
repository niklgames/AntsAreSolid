using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;

    public GameObject ant_1Prefab;
    public GameObject fireAntPrefab;
    public int numberOfAnts_1 = 100;
    public int numberOfFireAnts = 5;

    private List<GameObject> ants_1List = new List<GameObject>();
    private List<GameObject> fireAntsList = new List<GameObject>();

    private void Awake()
    {
        InstantiatePlayer();
    }

    private void Start()
    {
        InstantiateAnts_1();
        InstantiateFireAnts();
    }

    private void InstantiatePlayer()
    {
        GameObject player = Instantiate(playerPrefab, playerSpawnPosition.position, Quaternion.identity);
    }

    private void InstantiateAnts_1()
    {
        for (int i = 0; i < numberOfAnts_1; i++)
        {
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            GameObject ant = Instantiate(ant_1Prefab, Random.insideUnitCircle * 10, randomRotation);
            ants_1List.Add(ant);
        }
    }

    private void InstantiateFireAnts()
    {
        if(fireAntPrefab != null)
        {
            for (int i = 0; i < numberOfFireAnts; i++)
            {
                Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
                GameObject ant = Instantiate(fireAntPrefab, Random.insideUnitCircle * 10, randomRotation);
                fireAntsList.Add(ant);
            }
        }
        
    }
}
