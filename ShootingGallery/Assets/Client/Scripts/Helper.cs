using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public enum TagName {
        Room,
        MovementCurvy,
        RightTarget,
        WrongTarget,
        NeutralTarget,
        TargetPrefab,
    }
    public static Dictionary<TagName, string> Tags { get; } = new Dictionary<TagName, string>();
    public static Dictionary<TagName, string> Resource { get; } = new Dictionary<TagName, string>();
    static Helper()
    {
        Tags.Add(TagName.Room, "Room");
        Tags.Add(TagName.MovementCurvy, "MoveCurvy");

        Resource.Add(TagName.RightTarget, "Sprites/RightTarget");
        Resource.Add(TagName.WrongTarget, "Sprites/WrongTarget");
        Resource.Add(TagName.NeutralTarget, "Sprites/NeutralTarget");
        Resource.Add(TagName.TargetPrefab, "Assets/Client/Prefabs/Target.prefab"); 
    }

}
