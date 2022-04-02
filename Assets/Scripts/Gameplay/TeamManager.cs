using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    public List<TeamMember> members = new List<TeamMember>();

    public TeamManager targetTeam;

    private void Start()
    {
        members.Sort((x, y) => x.aggroStat.CompareTo(y.aggroStat));
    }

    public void Spawn(GameObject gameObject)
    {
        var go = Instantiate(gameObject, transform);
        var tm = go.GetComponent<TeamMember>();
        tm.team = this;
        members.Add(tm);
        members.Sort((x, y) => x.aggroStat.CompareTo(y.aggroStat));
    }

    public GameObject GetAggroTarget()
    {
        if (members.Count <= 0)
            return null;
        return members[members.Count - 1].gameObject;
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
