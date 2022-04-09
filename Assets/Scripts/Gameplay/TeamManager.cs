using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<TeamMember> members = new List<TeamMember>();

    [SerializeField] private Transform SpawnPoint;

    [SerializeField] private bool targetIsRandom = false;

    private List<TeamMember> tauntList = new List<TeamMember>();

    public TeamManager targetTeam;
    public bool isEnemyTeam = false;

    private void Start()
    {
        members.Sort((x, y) => x.aggroStat.CompareTo(y.aggroStat));
    }

    public void Spawn(CharacterProfile profile)
    {
        var tm = CharacterProfile.InitProfile(profile, SpawnPoint).GetComponent<TeamMember>();
        tm.team = this;
        members.Add(tm);
        members.Sort((x, y) => x.aggroStat.CompareTo(y.aggroStat));
    }

    public void Clear()
    {
        foreach (Transform t in SpawnPoint)
        {
            Destroy(t.gameObject);
        }
    }

    public GameObject GetAggroTarget()
    {
        if (members.Count <= 0)
            return null;
        if (tauntList.Count > 0)
            return tauntList[0].gameObject;
        int val = targetIsRandom ? Random.Range(0, members.Count) : members.Count-1;
        return members[val].gameObject;
    }

    public void Remove(TeamMember tm)
    {
        members.Remove(tm);
        if(members.Count <= 0)
        {
            if (isEnemyTeam)
                FindObjectOfType<GameManager>().CompleteWave();
        }
    }

    public void SetSpawnPointActive(bool value)
    {
        SpawnPoint.gameObject.SetActive(value);
    }

    public void AddToTauntList(GameObject go)
    {
        tauntList.Add(go.GetComponent<TeamMember>());
    }

    public void RemoveFromTauntList(GameObject go)
    {
        tauntList.Remove(go.GetComponent<TeamMember>());
    }
}
