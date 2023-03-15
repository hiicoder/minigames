using Photon.Pun;
using TMPro;
using UnityEngine;

public class GetSelfData : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    string number;
    [SerializeField] PhotonView photonView;
    // Start is called before the first frame update
    public void OnClickSelf()
    {
        number = text.text;
        SendDatatoall();
    }
    public void SendDatatoall()
    {

        photonView.RPC("RecivedDataToAll", RpcTarget.All,number);
    }
    [PunRPC]
    void RecivedDataToAll(string recivedData)
    {
        string data = recivedData;
        ActionHandler.ShowValue?.Invoke(data);
        Debug.Log(data);
       // text.text = "Number To Cut : " + data;
    }
}
