using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProfile
{
    public static string difficulty;
    public static int score;
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
