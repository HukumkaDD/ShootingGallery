using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Assets.Client.Scripts
{
    public static class Player
    {
        private static int score;
        public static int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        static Player()
        {
            score = 0;
        }

    }
}
