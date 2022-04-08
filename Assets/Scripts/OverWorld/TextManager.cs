using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI textUI;
    [SerializeField] private float textSpeed = 10;

    private int index;
    private int length;

    public void DisplayText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(CO_Appeartext(text));
    }

    public void Skip()
    {
        index = length - 1;
    }

    IEnumerator CO_Appeartext(string text)
    {
        yield return null;
        index = 0;
        length = text.Length;
        while (index < text.Length)
        {
            textUI.text = text.Substring(0, index);
            yield return new WaitForSeconds(1f / textSpeed);
            index++;
        }
        textUI.text = text;
        yield break;
    }
}
