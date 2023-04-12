using Photon.Pun;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetSelfData : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] PhotonView photonView;
    [SerializeField] ResultChecker checkResult;

    [SerializeField] string number;

    // Start is called before the first frame update

    private void Start()
    {
        photonView = gameObject.GetComponentInParent<PhotonView>();

    }
    private void OnEnable()
    {
        ActionHandler.DisableButton += DisableButtonClick;
        ActionHandler.TextToOther += Lose;
        ActionHandler.Onwin += DisableAllButtonOnWin;
    }
    private void OnDisable()
    {
        ActionHandler.DisableButton -= DisableButtonClick;
        ActionHandler.TextToOther -= Lose;
        ActionHandler.Onwin += DisableAllButtonOnWin;
    }

    /// <summary>
    /// Button Click function 
    /// Its sends the number which is crossed to others. 
    /// </summary>
    public void OnClickSelf()
    {
        number = text.text;
        ActionHandler.GetButtonValue.Invoke(number);
    }


    /// <summary>
    /// Make the button Non-interactable when Clicked
    /// </summary>
    public void DisableButtonClick()
    {
        if (gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void DisableAllButtonOnWin()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
    private void Lose()
    {
        photonView.RPC("RecivedWinOrLoseText", RpcTarget.Others, "You lose :(");
    }

}
