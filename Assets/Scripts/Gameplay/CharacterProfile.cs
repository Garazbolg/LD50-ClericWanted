using UnityEngine;

[CreateAssetMenu]
public class CharacterProfile : ScriptableObject
{
    public GameObject classPrefab;
    public int MaxHealth;
    public int MaxMana;
    public float AggroStat;
    public Sprite sprite;

    public static GameObject InitProfile(CharacterProfile profile, Transform parent)
    {
        var go = Instantiate(profile.classPrefab, parent);
        go.name = profile.name;

        var health = go.GetComponent<Gameplay.Health>();
        health.MaxValue = profile.MaxHealth;
        health.value = profile.MaxHealth;

        var mana = go.GetComponent<Mana>();
        mana.MaxValue = profile.MaxMana;

        var tm = go.GetComponent<TeamMember>();
        tm.aggroStat = profile.AggroStat;

        var cr = go.GetComponent<CharacterRenderer>();
        cr.Set(profile.sprite);
        return go;
    }
}