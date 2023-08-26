using System.Collections.Generic;
using UnityEngine;

public class AntManager : MonoBehaviour
{
    public GameObject antPrefab;
    public int numberOfAnts = 100;

    private List<GameObject> ants = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < numberOfAnts; i++)
        {
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            GameObject ant = Instantiate(antPrefab, Random.insideUnitCircle * 10, randomRotation);
            ants.Add(ant);
        }
    }
}
