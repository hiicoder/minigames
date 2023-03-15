using TMPro;
using UnityEngine;

public class ResultChecker : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Dropdown dropdown;
    public void PrintPattern()
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
                    text.text += " ";
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
                    text.text += " ";
                }

            }
            text.text += "<br>";
        }
    }
}
