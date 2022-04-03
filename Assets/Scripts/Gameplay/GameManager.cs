using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<CharacterProfile> playerTeamProfiles;
    public List<CharacterProfile> enemyTeamProfiles;
    public WaveDefinition[] waves;

    private int WaveIndex = 0;

    public TeamManager playerTeam;
    public TeamManager enemyTeam;

    private void Start()
    {
        if (playerTeamProfiles.Count > 5)
            Debug.LogError("Too many Characters");

        playerTeamProfiles.Sort((x, y) => x.AggroStat.CompareTo(y.AggroStat));

        foreach (var p in playerTeamProfiles)
        {
            playerTeam.Spawn(p);
        }

        NextWave();
    }

    private void NextWave()
    {
        if (WaveIndex > waves.Length)
        {
            Victory();
            return;
        }

        enemyTeamProfiles.Clear();

        foreach (var c in waves[WaveIndex].enemies)
        {
            enemyTeamProfiles.Add(c);
        }
        SetupEnemies();
    }

    private void SetupEnemies()
    {
        if (enemyTeamProfiles.Count > 5)
            Debug.LogError("Too many Characters");

        enemyTeamProfiles.Sort((x, y) => -x.AggroStat.CompareTo(y.AggroStat));
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
        
    }

    public static void Victory()
    {

    }

    public static void GameOver()
    {

    }
}
