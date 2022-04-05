using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DisableButtonOnPlateform : MonoBehaviour
{
    public List<RuntimePlatform> disabledPlatforms; 

    private void Start()
    {
        if (disabledPlatforms.Contains(UnityEngine.Application.platform))
        {
            var button = GetComponent<Button>();
            if(button)
                button.interactable = false;
        }
    }
}
