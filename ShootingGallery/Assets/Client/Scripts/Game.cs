using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Targets;
using System.Linq;

public class Game : MonoBehaviour
{
    public Texture2D scopeCursor;
    public GameObject ParentTarget;

    [Range(0, 10)]
    public float minTimeSpawn = 0.15f;
    [Range(0, 10)]
    public float maxTimeSpawn = 0.25f;
    [Range(0, 1000)]
    public float gameTime = 60f;

    private List<Target> _targets = new List<Target>();
    //private Timer _timer = new Timer(minTimeSpawn, maxTimeSpawn);
    private float _timer = 0;

    public void Start()
    {
        Cursor.SetCursor(scopeCursor, Vector2.zero, CursorMode.ForceSoftware);
        StartCoroutine(CreateTarget());
    }

    private IEnumerator CreateTarget()
    {
        while (true)
        {/*
            _targets.Add(TargetsManager.CreateTarget());
            _targets.Last().TargetGameObject.transform.SetParent(ParentTarget.transform);*/

            yield return new WaitForSeconds(gameTime);//Random.Range(minTimeSpawn, maxTimeSpawn));
        }

    }
    void Update()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            _timer = Random.Range(minTimeSpawn, maxTimeSpawn);
            _targets.Add(TargetsManager.CreateTarget());
            _targets.Last().TargetGameObject.transform.SetParent(ParentTarget.transform);
        }
        _targets.ForEach(x => x.MoveTarget());
    }
}
