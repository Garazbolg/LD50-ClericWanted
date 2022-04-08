using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<CharacterProfile> staticplayerTeamProfiles;
    public List<CharacterProfile> playerTeamProfiles = new List<CharacterProfile>();
    public List<CharacterProfile> enemyTeamProfiles;
    public WaveDefinition[] waves;

    private int WaveIndex = -1;

    public TeamManager playerTeam;
    public TeamManager enemyTeam;

    public float delayBetweenWaves = 3;

    private void Start()
    {
        if (staticplayerTeamProfiles != null)
        {
            playerTeamProfiles.Clear();
            playerTeamProfiles.AddRange(staticplayerTeamProfiles);
        }

        if (playerTeamProfiles.Count > 5)
            Debug.LogError("Too many Characters");

        playerTeamProfiles.Sort((x, y) =>x.AggroStat.CompareTo(y.AggroStat));

        foreach (var p in playerTeamProfiles)
        {
            playerTeam.Spawn(p);
        }

        NextWave();
    }

    public void CompleteWave()
    {
        AddReward(waves[WaveIndex].GoldReward, waves[WaveIndex].XPReward);
        StartCoroutine(CO_StartNextWave());
    }

    public int GetWaveIndex()
    {
        return WaveIndex;
    }
    public int GetMaxWaves()
    {
        return waves.Length;
    }

    private IEnumerator CO_StartNextWave()
    {
        yield return new WaitForSeconds(2);
        enemyTeam.Clear();
        enemyTeam.SetSpawnPointActive(false);
        yield return new WaitForSeconds(delayBetweenWaves-2);
        NextWave();
        enemyTeam.SetSpawnPointActive(true);
    }

    private void NextWave()
    {
        WaveIndex++;
        if (WaveIndex >= waves.Length)
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
        WorldMain.Gold += gold;
        WorldMain.XP += xp;
    }

    public void RunAway()
    {
        if (WorldMain.party != null)
            WorldMain.party.Clear();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    public static void Victory()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Victory", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public static void GameOver()
    {
        WorldMain.Gold = 0;
        WorldMain.XP = 0;
        if(WorldMain.party != null)
            WorldMain.party.Clear();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver",UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
