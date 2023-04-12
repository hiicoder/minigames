using Photon.Pun;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject layer;
    [SerializeField] Transform parent;
    [SerializeField] public GameObject child;
    [SerializeField] TMP_Text SendDataPos;
    PhotonView view;

    private void OnEnable()
    {
        ActionHandler.ShowValue += ShowValue;
        ActionHandler.SelfDisable += SelfDisable;
        ActionHandler.EnableOthers += SelfEnable;
    }

    private void OnDisable()
    {
        ActionHandler.ShowValue -= ShowValue;
        ActionHandler.SelfDisable -= SelfDisable;
        ActionHandler.EnableOthers -= SelfEnable;
    }

    private void ShowValue(string _value)
    {
        SendDataPos.text ="Last Cut: " +    _value.ToString();
    }

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {   
        child = PhotonNetwork.Instantiate("NumberBox", parent.position, Quaternion.identity);
        child.transform.parent = parent;     
    }
    private void SelfDisable()
    {
        layer.SetActive(true);
    }
    private void SelfEnable(bool val)
    {
        if (val)
        {
            layer.SetActive(false);
        }
    }

}
