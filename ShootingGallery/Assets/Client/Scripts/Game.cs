using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Targets;
using System.Linq;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

namespace Game
{
    public delegate void DeadHandler(ITarget target);
    public delegate void ScoreHandler();
    public delegate void TimerHandler();

    public class Game : MonoBehaviour
    {
        public Texture2D ScopeCursor;
        public GameObject ParentTarget;
        public Transform Pointer;
        public TextMeshProUGUI Score;
        public TextMeshProUGUI Time;

        [Range(0, 10)]
        [SerializeField] private float minTimeSpawn = 0.5f;
        [Range(0, 10)]
        [SerializeField] private float maxTimeSpawn = 1f;
        [Range(0, 1000)]
        [SerializeField] private float gameTime = 60f;

        private Timer _targetGenerateTimer;
        private Timer _endGameTimer;
        private Timer _currentTimer;
        private Vector2 _cursorOffset;
        private List<Target> _targets;

        public void Awake()
        {
            _targetGenerateTimer = new Timer(UpdateTargets, minTimeSpawn, maxTimeSpawn);
            _endGameTimer = new Timer(FinishGame, gameTime);
            _currentTimer = new Timer(UpdateTime, 1f);
            _cursorOffset = 16 * Vector2.one;
            _targets = new List<Target>();
        }
        public void Start()
        {
            Player.SetDefaultScore();
            Cursor.SetCursor(ScopeCursor, _cursorOffset, CursorMode.ForceSoftware);
            Player.ScoreChange = UpdateScore;
            Time.text = gameTime.ToString();
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
                Shoot();
            _targets.ForEach(x => x.MoveTarget());
            _targetGenerateTimer.Update();
            _endGameTimer.Update();
            _currentTimer.Update();
        }

        private void UpdateTargets()
        {
            _targets.Add(TargetsManager.CreateTarget());
            _targets.Last().TargetGameObject = Instantiate(_targets.Last().TargetGameObject);
            _targets.Last().TargetGameObject.transform.SetParent(ParentTarget.transform);
        }

        private void UpdateScore()
        {
            Score.text = Player.Score.ToString();
        }

        private void UpdateTime()
        {
            gameTime--;
            Time.text = gameTime.ToString();
        }

        private void FinishGame()
        {
            PlayerProfile.SavePlayer();
            SceneManager.LoadScene(Helper.Scenes[Helper.TagName.MainMenu]);
        }

        private void Shoot()
        {
            Ray ray = new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);

            if (!Physics.Raycast(ray, out RaycastHit hit))
                return;

            Pointer.position = hit.point;
            if (GameObject.Find(hit.collider.gameObject.name) == null)
                return;

            _targets.Find(x => x.TargetGameObject != null && x.TargetGameObject.name == hit.collider.gameObject.name).Hit();

            if (_targets.Exists(x => x.IsTargetLive == false))
                _targets.Remove(_targets.Find(x => x.IsTargetLive == false));

        }

    }
}