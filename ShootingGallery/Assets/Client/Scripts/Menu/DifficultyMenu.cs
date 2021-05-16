using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMenu : MonoBehaviour
{
    public void SetEasyDifficulty()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
        PlayerPrefs.Save();
    }

    public void SetMediumDifficulty()
    {
        PlayerPrefs.SetString("Difficulty", "Medium");
        PlayerPrefs.Save();
    }

    public void SetHardDifficulty()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
        PlayerPrefs.Save();
    }
}
