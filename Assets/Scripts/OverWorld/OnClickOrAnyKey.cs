using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnClickOrAnyKey : MonoBehaviour , IPointerDownHandler
{
    public UnityEvent OnClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke();
    }

    public void Invoke()
    {
        OnClick.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            Invoke();
        }
    }
}
