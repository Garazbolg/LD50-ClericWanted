using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaveDefinition : ScriptableObject
{
    public CharacterProfile[] enemies;

    public int GoldReward = 50;
    public int XPReward = 15;
}
