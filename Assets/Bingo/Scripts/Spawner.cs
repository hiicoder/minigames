using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject imagePrefab;
    [SerializeField] Transform parent;
    int gridSize;
    [SerializeField] GridLayoutGroup layout;
    List<GameObject> prefabs = new List<GameObject>();
    public List<int> numbers = new List<int>();
    // Start is called before the first frame update


    private void Start()
    {
        gridSize = Random.Range(5, 11);
        layout.constraintCount = gridSize;
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            numbers.Add(i);
            GameObject obj = Instantiate(imagePrefab, parent);
            prefabs.Add(obj);
        }
        SpawnGrid();    
    }

    private void SpawnGrid()
    {
        foreach (GameObject item in prefabs)
        {
            int randomPickup = Random.Range(0, numbers.Count);
            TMP_Text text = item.GetComponentInChildren<TMP_Text>();
            text.text = numbers[randomPickup].ToString();
            numbers.RemoveAt(randomPickup);
        }
    }
   
}
