using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<TeamMember> members = new List<TeamMember>();

    [SerializeField] private Transform SpawnPoint;
    private int currentIndex = 0;

    [SerializeField] private bool targetIsRandom = false;

    public TeamManager targetTeam;

    private void Start()
    {
        members.Sort((x, y) => x.aggroStat.CompareTo(y.aggroStat));
    }

    public void Spawn(CharacterProfile profile)
    {
        var tm = CharacterProfile.InitProfile(profile, SpawnPoint).GetComponent<TeamMember>();
        currentIndex++;
        tm.team = this;
        members.Add(tm);
        members.Sort((x, y) => x.aggroStat.CompareTo(y.aggroStat));
    }

    public GameObject GetAggroTarget()
    {
        if (members.Count <= 0)
            return null;
        int val = targetIsRandom ? Random.Range(0, members.Count) : members.Count-1;
        return members[val].gameObject;
    }

    public void Remove(TeamMember tm)
    {
        members.Remove(tm);
        if(members.Count <= 0)
        {
            Destroy(this);
        }
    }
}
