using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
         
    [Header("UI")]
    public Image image;

    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;
    
    public void InitializeItem(Item newItem) {
        item = newItem;
        image.sprite = newItem.image;
    }


    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
