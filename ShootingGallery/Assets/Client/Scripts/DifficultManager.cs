using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultManager
{
    public static string CurrentDifficult => PlayerPrefs.GetString(Helper.Tags[Helper.TagName.Difficulty]);
    public static void SetEasyDifficulty()
    {
        PlayerPrefs.SetString(Helper.Tags[Helper.TagName.Difficulty], Helper.Difficulty[Helper.TagName.Easy]);
        PlayerPrefs.Save();
    }

    public static void SetMediumDifficulty()
    {
        PlayerPrefs.SetString(Helper.Tags[Helper.TagName.Difficulty], Helper.Difficulty[Helper.TagName.Medium]);
        PlayerPrefs.Save();
    }

    public static void SetHardDifficulty()
    {
        PlayerPrefs.SetString(Helper.Tags[Helper.TagName.Difficulty], Helper.Difficulty[Helper.TagName.Hard]);
        PlayerPrefs.Save();
    }

}
