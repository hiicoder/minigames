using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SpawnGrid : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int gridSize = 5;
    List<GameObject> prefabs = new List<GameObject>();
    public List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };
    public GameObject[,] storeDataForCheckResult = new GameObject[5,5];
    float height= 110;
    float width = -110;
    PhotonView view;

    private void OnEnable()
    {
        ActionHandler.CrossOthersNumber += ActivateOthersCrossMark;
        ActionHandler.GetButtonValue += SendDataToOthers;
    }

    private void OnDisable()
    {
        ActionHandler.CrossOthersNumber -= ActivateOthersCrossMark;
        ActionHandler.GetButtonValue -= SendDataToOthers;
    }

    private void Start()
    {
        view = GetComponent<PhotonView>();  
        GenerateGrid();
    }

    #region Grid Generator and Shuffler

    /// <summary>
    /// Generate Grid When Game Start 
    /// </summary>
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
                storeDataForCheckResult[i, j] = child;
                RectTransform rectTransform = child.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = pose;
                width += 55;
            }
            height -= 55;
            width = -110;
        }
        ShuffleGrid();
    }

    /// <summary>
    /// Shuffle the grid number 
    /// </summary>
    private void ShuffleGrid()
    {
        foreach (GameObject item in prefabs)
        {
            int randomPickup = Random.Range(0, numbers.Count);
            TMP_Text text = item.GetComponentInChildren<TMP_Text>();
            text.text = numbers[randomPickup].ToString();
            numbers.RemoveAt(randomPickup);
        }
    }

    #endregion


    /// <summary>
    /// Activate Cross mark on other players grid boxes. 
    /// </summary>
    /// <param name="buttonNumber">Get the Grid button number</param>
    private void ActivateOthersCrossMark(string buttonNumber)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (buttonNumber == child.GetComponentInChildren<TMP_Text>().text)
            {
                child.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void SendDataToOthers(string number)
    {
        view.RPC("ReceivedDataToOther", RpcTarget.Others,number);
        view.RPC("EnableOthers", RpcTarget.All, true);
        view.RPC("EnableOthers", RpcTarget.Others, true);
        ActionHandler.SelfDisable?.Invoke();
        view.RPC("CheckResult", RpcTarget.All);
    }

    [PunRPC]
    void ReceivedDataToOther(string receivedData)
    {
        Debug.Log(receivedData);
        ActionHandler.CrossOthersNumber?.Invoke(receivedData);
    }
    [PunRPC]
    void EnableOthers(bool val)
    {
        ActionHandler.DisableButton?.Invoke();
        ActionHandler.EnableOthers?.Invoke(val);
    }

    [PunRPC]
    void CheckResult()
    {
        ActionHandler.CheckResult?.Invoke();
    }


    [PunRPC]
    void OnWin()
    {
        ActionHandler.Onwin?.Invoke();
    }

    [PunRPC]
    void RecivedWinOrLoseText(string text)
    {
        ActionHandler.WinORLoseText?.Invoke(text);
    }
}
