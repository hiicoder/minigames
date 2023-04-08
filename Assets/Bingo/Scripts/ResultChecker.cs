using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultChecker : MonoBehaviour
{
    [SerializeField] List<GameObject> bingo = new List<GameObject>();

    SpawnGrid spawnGrid;
    int count = 0;
    private void Start()
    {
        spawnGrid = FindObjectOfType<SpawnGrid>();
    }
    private void OnEnable()
    {
        //ActionHandler.CheckResult += CheckResult;
    }

    private void OnDisable()
    {
       //ActionHandler.CheckResult -= CheckResult;

    }

    public void CheckResult() 
    {
        CheckRow_0();
        CheckRow_1();
        CheckRow_2();
        CheckRow_3();
        CheckRow_4();
        CheckCol_0();
        CheckCol_1();
        CheckCol_2();
        CheckCol_3();
        CheckCol_4();
       
    }

    #region Row Check
    public void CheckRow_0()
    {
            for (int j = 0; j < 5; j++)
            {
                if (spawnGrid.arrayObjects[0, j].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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
            if (!bingo[0].transform.GetChild(1).gameObject.activeInHierarchy)
            {
                bingo[0].transform.GetChild(1).gameObject.SetActive(true);
            }
            else if(!bingo[1].transform.GetChild(1).gameObject.activeInHierarchy)
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
    }
    public void CheckRow_1()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[1, j].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[1].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckRow_2()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[2, j].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[2].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckRow_3()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[3, j].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[3].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckRow_4()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[3, j].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[4].transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    #endregion


    #region Col Check
    public void CheckCol_0()
    {
            for (int j = 0; j < 5; j++)
            {
                if (spawnGrid.arrayObjects[j, 0].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[0].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckCol_1()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[j, 0].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[1].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckCol_2()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[j, 0].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[2].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckCol_3()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[j, 0].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[3].transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    public void CheckCol_4()
    {
        for (int j = 0; j < 5; j++)
        {
            if (spawnGrid.arrayObjects[j, 0].gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
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

            bingo[4].transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    #endregion

    /*public void PrintPattern()
        {

            if (dropdown.value == 0)
            {
                text.text = "";
                HorizontalPattern();
            }
            if (dropdown.value == 1)
            {
                text.text = "";
                VerticalPattern();

            }
            if (dropdown.value == 2)
            {
                text.text = "";
                DigonalPatternRight();
            }
            if (dropdown.value == 3)
            {
                text.text = "";
                DigonalPatternLeft();
            }


        }

       public void HorizontalPattern()
        {
            for (int i = 0; i < 5; i++)
            {
                text.text += "*";
            }
        } 
        public void VerticalPattern()
        {
            for (int i = 0; i < 5; i++)
            {
                text.text += "* <br>";
            }
        }
        public void DigonalPatternLeft()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5 ; j++)
                {
                    if (i == j)
                    {
                        text.text += "*";
                    }
                    else
                    {
                        text.text += "   ";
                    }

                }
                text.text += "<br>";
            }
        }
        public void DigonalPatternRight()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i + j == 4 )
                    {
                        text.text += "*";
                    }
                    else
                    {
                        text.text += "   ";
                    }

                }
                text.text += "<br>";
            }
        }*/
}
