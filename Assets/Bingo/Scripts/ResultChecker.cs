using Photon.Pun;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultChecker : MonoBehaviour
{
    [SerializeField] List<GameObject> bingo = new List<GameObject>();

    SpawnGrid spawnGrid;
    int count = 0;
    int columnCount = 0;
    int rowCount = 0;
    int diagonalCountLeft = 0;
    int diagonalCountRight = 0;
    List<int> rowArray = new List<int>();
    List<int> colArray = new List<int>();
    [SerializeField] TMP_Text winText;
    

    private void Start()
    {
        spawnGrid = FindObjectOfType<SpawnGrid>();
        
    }
    private void OnEnable()
    {
        ActionHandler.CheckResult += CheckResult;
        ActionHandler.WinORLoseText += WinLoseText;
    }

    private void OnDisable()
    {
       ActionHandler.CheckResult -= CheckResult;
        ActionHandler.WinORLoseText -= WinLoseText;

    }

   
  

    
    public void CheckResult()
    {
        CheckRow_0();
        CheckCol_0();
        if (diagonalCountLeft == 0)
        {
            CheckDiagonalLeft();
            
        }
        if (diagonalCountRight == 0)
        {
            CheckDiagonalRight();
        }

    }

    #region Row Check
    public void CheckRow_0()
    {
        
        for (int i = 0; i < 5; i++)
        {
            if (rowArray.Contains(i))
            {
                continue;
            }
            for (int j = 0; j < 5; j++)
            {
                if (spawnGrid.arrayObjects[i, j].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
                {
                    count++;
                    
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            if (count == 5)
            {
                count = 0;
                rowArray.Add(i);
                checkIsActive("rowCall");
            }
        }
    }
    #endregion


    #region Col Check
    public void CheckCol_0()
    {
        for (int i = 0; i < 5; i++)
        {
            if (colArray.Contains(i))
            {
                continue;
            }
            for (int j = 0; j < 5; j++)
            {
               
                if (spawnGrid.arrayObjects[j, i].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            if (count == 5)
            {
                count = 0;
                colArray.Add(i);
                checkIsActive("colCall");
            }
        }
    }
    #endregion


    #region Diagonal Check

    public void CheckDiagonalLeft()
    {
        for (int i = 0; i < 5; i++)
        {
            if (spawnGrid.arrayObjects[i, i].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                count++;
            }
            else
            {
                count = 0;
                break;
            }
        }
        if (count == 5)
        {
            count = 0;
            checkIsActive("diagonalCallLeft");
        }
    }
    public void CheckDiagonalRight()
    {
        for (int i = 0; i < 5; i++)
        {
            if (spawnGrid.arrayObjects[i, 4 - i].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                count++;
            }
            else
            {
                count = 0;
                break;
            }
        }
        if (count == 5)
        {
            count = 0;
            checkIsActive("diagonalCallRight");
        }
    }


    #endregion


    private void checkIsActive( string callValue)
    {
        if (callValue == "rowCall")
        {
            rowCount++;
        }
        else if (callValue == "colCall")
        {
            columnCount++;
        }
        else if (callValue == "diagonalCallLeft")
        {
            diagonalCountLeft++;
        }
        else if (callValue == "diagonalCallRight")
        {
            diagonalCountRight++;
        }

            if (!bingo[0].transform.GetChild(1).gameObject.activeInHierarchy)
            {
                bingo[0].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (!bingo[1].transform.GetChild(1).gameObject.activeInHierarchy)
            {
                bingo[1].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (!bingo[2].transform.GetChild(1).gameObject.activeInHierarchy)
            {
                bingo[2].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (!bingo[3].transform.GetChild(1).gameObject.activeInHierarchy)
            {
                bingo[3].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if (!bingo[4].transform.GetChild(1).gameObject.activeInHierarchy)
            {
                bingo[4].transform.GetChild(1).gameObject.SetActive(true);
            }
       
    }

    public void WinLoseText(string text)
    {
        bool val = false;
        foreach (var item in bingo)
        {

            if (item.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }
        if (val)
        {
            winText.text = text;
            ActionHandler.TextToOther?.Invoke();
        }
    }


   
}
