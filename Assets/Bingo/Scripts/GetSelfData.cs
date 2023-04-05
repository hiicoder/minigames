using Photon.Pun;
using TMPro;
using UnityEngine;

public class GetSelfData : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] PhotonView photonView;
    [SerializeField] string number;

    // Start is called before the first frame update

    private void Start()
    {
        photonView = gameObject.GetComponentInParent<PhotonView>();
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
    }

    public void SendDataToOther()
    {
        photonView.RPC("RecivedDataToOther", RpcTarget.Others, true);
        ActionHandler.SelfDisable?.Invoke();
    }
}
