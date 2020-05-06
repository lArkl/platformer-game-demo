using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int points;
    public static int extraJumps;
    public static int nPowers;
    public static int nDeaths;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void OnDeath()
    {
        points = 0;
        nPowers = 0;
        nDeaths++;
    }
}
