using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInspectorTarget : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.playerInspector.Setup(gameObject);
        SelectableCharacter.Setup(gameObject, Color.yellow);
    }
}
