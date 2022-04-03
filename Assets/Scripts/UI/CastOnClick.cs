using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CastOnClick : MonoBehaviour, IPointerClickHandler
{
    private int index;

    public void Setup(int index)
    {
        this.index = index;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerController.Instance.Cast(index);
    }
}