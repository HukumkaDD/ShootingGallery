using Game;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private (string, int) record;
    public PlayerData()
    {
        record.Item1= DifficultManager.CurrentDifficult;
        record.Item2 = Player.Score;
    }

    public (string, int) Data()
    {
        return record;
    }
}
