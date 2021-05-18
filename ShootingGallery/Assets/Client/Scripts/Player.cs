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

        public static GameObject ShootingTarget(Transform transform)
        {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);

            if (!Physics.Raycast(ray, out RaycastHit hit))
                return null;

            if (GameObject.Find(hit.collider.gameObject.name) == null)
                return null;
            return hit.collider.gameObject;
        }
    }
}