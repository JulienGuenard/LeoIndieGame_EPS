using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPS_DifficultyManager : MonoBehaviour {

    public static EPS_DifficultyManager Instance;

    public float ballSpeed;
    public float ballSpeedGrow;
    public float ballSpeedGrowScoreRequired;

    public float ballSpawnDelay;
    public float ballSpawnDelayGrow;
    public float ballSpawnDelayGrowScoreRequired;

    public float fireChance;
    public float fireChanceGrow;
    public float fireChanceGrowScoreRequired;

    public float biggerChance;
    public float biggerChanceGrow;
    public float biggerChanceGrowScoreRequired;

    void Awake ()
    {
        Instance = this;
	}
	
public void DifficultyGrow(float score) // by add score
    {
        if (score >= ballSpeedGrowScoreRequired)
        ballSpeed += ballSpeedGrow;

        if (score >= ballSpawnDelayGrowScoreRequired)
            ballSpawnDelay += ballSpawnDelayGrow;

        if (score >= fireChanceGrowScoreRequired)
            fireChance += fireChanceGrow;

        if (score >= biggerChanceGrowScoreRequired)
            biggerChance += biggerChanceGrow;
    }
}
