using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public enum TagName
    {
        Room,
        MovementCurvy,
        RightTarget,
        WrongTarget,
        NeutralTarget,
        DeadTarget,
        TargetPrefab,
        Difficulty,
        Easy,
        Medium,
        Hard,
        DefaultShootingGallery,
        MainMenu,
        PlayerSave,
        AmongDeathSound,
        GunShotSound,
        RicochetSound,
        MistakeShotSound,
    }
    public static Dictionary<TagName, string> Tags { get; } = new Dictionary<TagName, string>();
    public static Dictionary<TagName, string> Resource { get; } = new Dictionary<TagName, string>();
    public static Dictionary<TagName, string> Difficulty { get; } = new Dictionary<TagName, string>();
    public static Dictionary<TagName, string> Scenes { get; } = new Dictionary<TagName, string>();
    public static Dictionary<TagName, string> SaveFiles { get; } = new Dictionary<TagName, string>();
    public static Dictionary<TagName, string> Audio { get; } = new Dictionary<TagName, string>();
    static Helper()
    {
        Tags.Add(TagName.Room, "Room");
        Tags.Add(TagName.MovementCurvy, "MoveCurvy");
        Tags.Add(TagName.Difficulty, "Difficulty");

        Resource.Add(TagName.RightTarget, "Sprites/RightTarget");
        Resource.Add(TagName.WrongTarget, "Sprites/WrongTarget");
        Resource.Add(TagName.NeutralTarget, "Sprites/NeutralTarget");
        Resource.Add(TagName.DeadTarget, "Sprites/DeadTarget/among-dead");
        Resource.Add(TagName.TargetPrefab, "Assets/Client/Prefabs/Target.prefab");

        Difficulty.Add(TagName.Easy, "Easy");
        Difficulty.Add(TagName.Medium, "Medium");
        Difficulty.Add(TagName.Hard, "Hard");

        Scenes.Add(TagName.DefaultShootingGallery, "DefaultShootingGallery");
        Scenes.Add(TagName.MainMenu, "Menu");

        SaveFiles.Add(TagName.PlayerSave, "/SaveFiles.save");

        Audio.Add(TagName.AmongDeathSound, "among-death");
        Audio.Add(TagName.GunShotSound, "gun-shot");
        Audio.Add(TagName.RicochetSound, "ricochet");
        Audio.Add(TagName.MistakeShotSound, "mistake-shot");
    }

}
