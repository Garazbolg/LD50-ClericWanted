using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textUI;
    [SerializeField] private float textSpeed = 10;

    public void DisplayText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(CO_Appeartext(text));
    }

    IEnumerator CO_Appeartext(string text)
    {
        yield return null;
        int index = 0;
        while(index < text.Length)
        {
            index++;
            textUI.text = text.Substring(0, index);
            yield return new WaitForSeconds(1f / textSpeed);
        }
        textUI.text = text;
        yield break;
    }
}
