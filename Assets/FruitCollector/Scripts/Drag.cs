using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Drag : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragg");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        transform.SetParent(parentAfterDrag);
    }

   
}