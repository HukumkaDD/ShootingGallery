using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Targets;
using System.Linq;
using Rooms;

public class GameController : MonoBehaviour
{
    public Texture2D scopeCursor;
    public GameObject Target;
    public GameObject[] targetsObj;

    public float minTimeSpawn = 1f;
    public float maxTimeSpawn = 4f;

    public int evilChance = 10;
    public int neutralChance = 2;
    public int goodChance = 3;

    private List<Target> targets;
    private List<Transform> prefabTargets;
    public void Start()
    {
        Cursor.SetCursor(scopeCursor, Vector2.zero, CursorMode.ForceSoftware);
        targets = new List<Target>();
        prefabTargets = new List<Transform>();
        StartCoroutine(CreateTarget());
    }

    IEnumerator CreateTarget()
    {
        while (true)
        {
            targets.Add(TargetManager.CreateTarget(Room.third, evilChance, goodChance, neutralChance));
            prefabTargets.Add(Instantiate(targetsObj[0].transform, targets.Last().gameObject.transform.position, Quaternion.identity));
            prefabTargets.Last().transform.SetParent(Target.transform);
            yield return new WaitForSeconds(Random.Range(minTimeSpawn, maxTimeSpawn));
        }

    }
    void Update()
    {

    }
}
