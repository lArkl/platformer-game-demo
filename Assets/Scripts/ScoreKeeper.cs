using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static int coins;
    public static int extraJumps;
    public static int powers;
    public static int deaths;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void OnDeath()
    {
        coins = 0;
        powers = 0;
        extraJumps = 0;
        deaths++;
    }

    public static void OnReset()
    {
        OnDeath();
        deaths = 0;
    }
}
