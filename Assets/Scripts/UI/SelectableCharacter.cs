using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCharacter : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        ClassInspector.Instance.Setup(transform.parent.gameObject);
        PlayerTargeter.target = transform.parent.gameObject;
    }
}
