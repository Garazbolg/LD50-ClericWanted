using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRenderer : MonoBehaviour
{
    public Image image;

    public void Set(Sprite sprite)
    {
        image.sprite = sprite;
    }

    public Sprite Get()
    {
        return image.sprite;
    }
}
