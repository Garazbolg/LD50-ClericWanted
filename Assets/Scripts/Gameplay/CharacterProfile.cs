using UnityEngine;

[CreateAssetMenu]
public class CharacterProfile : ScriptableObject
{
    public GameObject classPrefab;
    public int MaxHealth;
    public int MaxMana;
    public float AggroStat;

    public static GameObject InitProfile(CharacterProfile profile, Transform parent)
    {
        var go = Instantiate(profile.classPrefab, parent);
        go.name = profile.name;
        var health = go.GetComponent<Gameplay.Health>();
        var mana = go.GetComponent<Mana>();
        var tm = go.GetComponent<TeamMember>();
        health.MaxValue = profile.MaxHealth;
        health.value = profile.MaxHealth;
        mana.MaxValue = profile.MaxMana;
        tm.aggroStat = profile.AggroStat;
        return go;
    }
}