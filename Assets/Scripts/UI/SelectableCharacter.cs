using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCharacter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color HighlightedColor = Color.white;


    public void OnPointerClick(PointerEventData eventData)
    {
        var go = transform.parent.gameObject;

        Setup(go, HighlightedColor);
    }

    public static void Setup(GameObject gggo,Color color)
    {
        var go = gggo;

        if (UIManager.Instance.selectedUnit != null)
        {
            UIManager.Instance.selectedUnit.GetComponent<CharacterRenderer>().frame.color = Color.white;
        }

        UIManager.Instance.selectedUnit = go;
        UIManager.Instance.selectedUnit.GetComponent<CharacterRenderer>().frame.color = color;
        ClassInspector.Instance.Setup(go);
        PlayerTargeter.target = go;
    }
}
