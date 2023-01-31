using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    [SerializeField] private List<GameObject> fruits = new List<GameObject>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fruit = fruits[Random.Range(0,fruits.Count)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(fruit, spawnPoint);
        }
    }
}
