using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<CharacterProfile> playerTeamProfiles;
    public List<CharacterProfile> enemyTeamProfiles;

    public TeamManager playerTeam;
    public TeamManager enemyTeam;

    private void Start()
    {
        if (playerTeamProfiles.Count > 5)
            Debug.LogError("Too many Characters");
        if (enemyTeamProfiles.Count > 5)
            Debug.LogError("Too many Characters");

        playerTeamProfiles.Sort((x, y) => x.AggroStat.CompareTo(y.AggroStat));
        enemyTeamProfiles.Sort((x, y) => -x.AggroStat.CompareTo(y.AggroStat));

        foreach (var p in playerTeamProfiles)
        {
            playerTeam.Spawn(p);
        }
        foreach (var e in enemyTeamProfiles)
        {
            enemyTeam.Spawn(e);
        }
    }

    public void AddReward(int gold,int xp)
    {

    }

    public void RunAway()
    {
        playerTeamProfiles.Clear();
    }
}
