using Photon.Pun;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    [SerializeField] Transform parent;
    int gridSize;
    [SerializeField] GridLayoutGroup layout;
    List<GameObject> prefabs = new List<GameObject>();
    public List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
    [SerializeField] TMP_Text SendDataPos;
    // Start is called before the first frame update

    private void OnEnable()
    {
        ActionHandler.ShowValue += ShowValue;
    }

    private void OnDisable()
    {
        ActionHandler.ShowValue -= ShowValue;

    }


    private void ShowValue(string _value)
    {
        SendDataPos.text = _value.ToString();
    }

    private void Start()
    {
        
        gridSize = 5;
        layout.constraintCount = gridSize;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < gridSize * gridSize; i++)
        {
            GameObject obj =PhotonNetwork.Instantiate("1", parent.position,Quaternion.identity);
            obj.transform.parent = parent;
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
