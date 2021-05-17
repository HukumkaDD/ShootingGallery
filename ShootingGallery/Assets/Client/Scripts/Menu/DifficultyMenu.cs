using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyMenu : MonoBehaviour
{
    public void SetEasyDifficulty()
    {
        DifficultManager.SetEasyDifficulty();
    }

    public void SetMediumDifficulty()
    {
        DifficultManager.SetMediumDifficulty();
    }

    public void SetHardDifficulty()
    {
        DifficultManager.SetHardDifficulty();
    }
}
