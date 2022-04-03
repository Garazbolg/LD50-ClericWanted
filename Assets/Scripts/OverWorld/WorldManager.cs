using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private void Awake()
    {
#if UNITY_EDITOR
        WorldMain.Init();
#endif
    }
}
