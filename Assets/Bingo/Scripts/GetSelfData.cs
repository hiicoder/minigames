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
    }

    

    private void OnDisable()
    {
        ActionHandler.DisableButton -= DisableButtonClick;
        ActionHandler.TextToOther -= Lose;

    }

    public void OnClickSelf()
    {
        number = text.text;
        SendDatatoall();
        SendDataToOther();
    }
    public void SendDatatoall()
    {
        photonView.RPC("RecivedDataToAll", RpcTarget.All, number);
        photonView.RPC("CheckResultAndDisableButton", RpcTarget.All);
    }

    public void SendDataToOther()
    {
        photonView.RPC("RecivedDataToOther", RpcTarget.Others, true);
        ActionHandler.SelfDisable?.Invoke();

    }


    public void DisableButtonClick()
    {
        if (gameObject.transform.GetChild(1).gameObject.activeInHierarchy)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
    private void Lose()
    {
        ActionHandler.WinORLoseText?.Invoke("You Win :)");
        photonView.RPC("RecivedWinOrLoseText", RpcTarget.Others, "You lose :(");
    }

}
