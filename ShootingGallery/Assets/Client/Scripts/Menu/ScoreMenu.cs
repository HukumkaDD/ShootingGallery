using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI[] Leaders;
    public TextMeshProUGUI Difficult;

    private List<string> difficults;
    private Dictionary<string, (string, int)[]> _records;
    private int _countLeadres = 5;
    private int _currentIndexDifficult;
    public void ShowRecords()
    {
        if (Leaders.Length != _countLeadres)
            return;

        difficults = new List<string>();
        _records = new Dictionary<string, (string, int)[]>();

        var data = PlayerProfile.data;
        foreach (KeyValuePair<Helper.TagName, string> difficulty in Helper.Difficulty)
        {
            if (data != null)
            {
                var dataDifficulty = data
                    .Where(x => x.Item1 == Helper.Difficulty[difficulty.Key])
                    .OrderByDescending(y => y.Item2)
                    .Take(_countLeadres)
                    .ToArray();
                difficults.Add(Helper.Difficulty[difficulty.Key]);
                _records.Add(Helper.Difficulty[difficulty.Key], dataDifficulty);
            }
            else
            {
                var emptyRecords = Array.Empty<(string, int)>();
                difficults.Add(Helper.Difficulty[difficulty.Key]);
                _records.Add(Helper.Difficulty[difficulty.Key], emptyRecords);

            }

        }
        _currentIndexDifficult = 0;
        UpdateLeaders();
    }

    public void ChangeDifficult(int direction)
    {
        int newIndexDifficult = _currentIndexDifficult + direction;
        if (newIndexDifficult < 0 || newIndexDifficult > difficults.Count-1)
            return;
        if (Leaders.Length != _countLeadres)
            return;
        _currentIndexDifficult = newIndexDifficult;
        UpdateLeaders();
    }

    private void UpdateLeaders()
    {
        for (int i = 0; i < Leaders.Length; i++)
            Leaders[i].text =String.Empty;

        Difficult.text = difficults[_currentIndexDifficult];
        if (_records[difficults[_currentIndexDifficult]] == null)
            return;

        for (int i = 0; i < _records[difficults[_currentIndexDifficult]].Length; i++)
            Leaders[i].text = _records[difficults[_currentIndexDifficult]][i].Item2.ToString();
    }
}
