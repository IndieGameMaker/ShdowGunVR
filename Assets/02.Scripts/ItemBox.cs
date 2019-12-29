using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnLookAt(bool isLook)
    {
        // Debug.Log("isLook=" + isLook);
        // MoveCtrl.isStopped = isLook;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MoveCtrl.isStopped = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MoveCtrl.isStopped = false;
    }
}
