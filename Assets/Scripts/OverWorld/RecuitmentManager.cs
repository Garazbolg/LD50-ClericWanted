using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecuitmentManager : MonoBehaviour
{
    public int numberOfRecruits = 3;
    public CharacterProfile[] pool;
    public Transform recruitsTranforms;
    public RecruitView recruitViewPrefab;
    public PartyDisplay partyDisplay;

    public void OnEnable()
    {
        Setup();
    }

    public void Setup()
    {
        partyDisplay.Setup();
        if(WorldMain.party == null || WorldMain.party.Count >= 3)
        {
            PartyViewManager.instance.DisplayText("Your party is already full.\n Time to explore some dungeons !");
            recruitsTranforms.gameObject.SetActive(false);
            return;
        }

        foreach (Transform t in recruitsTranforms)
        {
            Destroy(t.gameObject);
        }
        var profiles = Get(numberOfRecruits);
        foreach (var p in profiles)
        {
            var go = Instantiate(recruitViewPrefab, recruitsTranforms);
            go.Setup(p,this);
        }
    }

    CharacterProfile[] Get(int number)
    {
        List<int> ints = new List<int>();
        for (int i = 0; i < pool.Length; i++)
        {
            ints.Add(i);
        }
        ints.Shuffle();
        List<CharacterProfile> res = new List<CharacterProfile>();
        for (int i = 0; i < number; i++)
        {
            res.Add(pool[ints[i]]);
        }
        return res.ToArray();
    }
}
