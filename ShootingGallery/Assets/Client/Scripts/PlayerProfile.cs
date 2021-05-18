using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProfile
{
    //[HideInInspector]
    public static string difficulty;
    //[HideInInspector]
    public static int score;
    //[HideInInspector]
    public static (string, int)[] data;

    public static void SavePlayer()
    {
        SaveSystem.SaveRecordPlayer();
    }

    public static void LoadPlayer()
    {
        data = SaveSystem.LoadRecordPlayer();
    }
}
