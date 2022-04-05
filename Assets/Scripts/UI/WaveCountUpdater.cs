using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCountUpdater : MonoBehaviour
{
    public GameManager gameManager;
    public TMPro.TextMeshProUGUI textMesh;

    private void Update()
    {
        textMesh.text = $"Wave {gameManager.GetWaveIndex()+1} out of {gameManager.GetMaxWaves()}";
    }
}
