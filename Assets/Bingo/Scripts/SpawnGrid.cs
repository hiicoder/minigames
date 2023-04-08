using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SpawnGrid : MonoBehaviour
{
    
    List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] GameObject prefab;
    public GameObject[,] arrayObjects = new GameObject[5,5];
    public List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
    int gridSize;
    float height= 110;
    float width = -110;


    private void OnEnable()
    {
       
        ActionHandler.PlayerTurn += ActivateOrDeactivateButtons;

    }

    private void OnDisable()
    {
        
        ActionHandler.PlayerTurn -= ActivateOrDeactivateButtons;
    }


    private void Start()
    {
        gridSize = 5;
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 pose = new Vector3(width, height, 0);
                GameObject child = Instantiate(prefab);
                child.transform.parent = gameObject.transform;
                prefabs.Add(child);
                arrayObjects[i, j] = child;
                RectTransform rectTransform = child.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = pose;
                width += 55;
            }
            height -= 55;
            width = -110;
        }
        SufflGrid();
    }

    private void SufflGrid()
    {
        foreach (GameObject item in prefabs)
        {
            int randomPickup = Random.Range(0, numbers.Count);
            TMP_Text text = item.GetComponentInChildren<TMP_Text>();
            text.text = numbers[randomPickup].ToString();
            numbers.RemoveAt(randomPickup);
        }
    }

    private void ActivateOrDeactivateButtons(string num)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (num == child.GetComponentInChildren<TMP_Text>().text)
            {
              child.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
   

    [PunRPC]
    void RecivedDataToAll(string recivedData)
    {
        string data = recivedData;
        ActionHandler.ShowValue?.Invoke(data);
        ActionHandler.PlayerTurn?.Invoke(data);
    }

    [PunRPC]
    void RecivedDataToOther(bool val)
    {
        ActionHandler.EnableOthers?.Invoke(val);
        
    }

}
