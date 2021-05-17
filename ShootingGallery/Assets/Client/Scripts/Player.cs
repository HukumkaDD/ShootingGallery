using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targets;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

namespace Game
{
    public static class Player
    {
        public static ScoreHandler ScoreChange;
        public static int Score { get; private set; }

        static Player()
        {
            Score = 0;
        }

        public static void UpdateScore(int score)
        {
            Score += score;
            ScoreChange?.Invoke();
        }

        public static void SetDefaultScore()
        {
            Score = 0;
        }

    }
}