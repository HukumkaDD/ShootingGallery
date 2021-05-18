using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using UnityEditor;
using System.Runtime.ExceptionServices;

namespace Targets
{
    delegate Target CreateTypeTarget(string roomName, GameObject movmentCurve);
    delegate int DifficultyLogic();
    enum TypeTarget
    {
        rightTarget,
        neutralTarget,
        wrongTarget,
    }

    public static class TargetsManager
    {
        [Range(0, 100)]
        public static int rightChance = 10;
        [Range(0, 100)]
        public static int neutralChance = 5;
        [Range(0, 100)]
        public static int wrongChance = 5;

        public static Sprite[] rightSprites = Resources.LoadAll<Sprite>(Helper.Resource[Helper.TagName.RightTarget]);
        public static Sprite[] wrongSprites = Resources.LoadAll<Sprite>(Helper.Resource[Helper.TagName.WrongTarget]);
        public static Sprite[] neutralSprites = Resources.LoadAll<Sprite>(Helper.Resource[Helper.TagName.NeutralTarget]);

        private static GameObject _target = AssetDatabase.LoadAssetAtPath<GameObject>(Helper.Resource[Helper.TagName.TargetPrefab]);
        private static int _idTarget = 0;

        private static readonly CreateTypeTarget[] GenerateTargets =
        {
            new CreateTypeTarget(CreateRightTarget),
            new CreateTypeTarget(CreateNeutralTarget),
            new CreateTypeTarget(CreateWrongTarget),
        };
        private static readonly (string, DifficultyLogic)[] DifficultyLogics =
        {
            (Helper.Difficulty[Helper.TagName.Easy],new DifficultyLogic(EasyLogic)),
            (Helper.Difficulty[Helper.TagName.Medium],new DifficultyLogic(MediumLogic)),
            (Helper.Difficulty[Helper.TagName.Hard],new DifficultyLogic(HardLogic)),
        };

        static TargetsManager()
        {
            if (!PlayerPrefs.HasKey(Helper.Tags[Helper.TagName.Difficulty]))
                DifficultManager.SetEasyDifficulty();

        }

        public static Target CreateTarget()
        {
            System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

            // Выбираем случайную комнату
            GameObject[] rooms = GameObject.FindGameObjectsWithTag(Helper.Tags[Helper.TagName.Room]);
            GameObject room = rooms.Skip(random.Next(rooms.Length)).First();

            // Определяем маршут цели в выбранной комнате
            GameObject movmentCurve = room.transform.GetChild(random.Next(room.transform.childCount)).gameObject;

            // Определяем тип мишени в соотвествии со сложностью
            int typeTargetIndex = DifficultyLogics.Where(x => x.Item1 == DifficultManager.CurrentDifficult).First().Item2();

            // Создаем мишень
            return GenerateTargets[typeTargetIndex](room.name, movmentCurve);
        }

        private static Target CreateRightTarget(string roomName, GameObject movmentCurve)
        {
            InstatiateTransform(movmentCurve);
            InstantiateRenderer(rightSprites, roomName);
            return new RightTarget(_target, movmentCurve);
        }

        private static Target CreateNeutralTarget(string roomName, GameObject movmentCurve)
        {
            InstatiateTransform(movmentCurve);
            InstantiateRenderer(neutralSprites, roomName);
            return new NeutralTarget(_target, movmentCurve);
        }

        private static Target CreateWrongTarget(string roomName, GameObject movmentCurve)
        {
            InstatiateTransform(movmentCurve);
            InstantiateRenderer(wrongSprites, roomName);
            return new WrongTarget(_target, movmentCurve);
        }

        private static int EasyLogic()
        {
            return (int)TypeTarget.rightTarget;
        }

        private static int MediumLogic()
        {
            System.Random random = new System.Random();
            int targetChance = random.Next(rightChance + neutralChance);

            if (targetChance <= rightChance)
                return (int)TypeTarget.rightTarget;
            else
                return (int)TypeTarget.neutralTarget;

        }

        private static int HardLogic()
        {
            System.Random random = new System.Random();
            int targetChance = random.Next(rightChance + wrongChance + neutralChance);

            if (targetChance <= rightChance)
                return (int)TypeTarget.rightTarget;
            if (targetChance > rightChance && targetChance < rightChance + wrongChance)
                return (int)TypeTarget.wrongTarget;

            return (int)TypeTarget.neutralTarget;
        }

        private static void InstantiateRenderer(Sprite[] sprites, string roomName)
        {
            System.Random random = new System.Random();
            var spriteRenderer = _target.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites.Skip(random.Next(0, sprites.Length)).First();
            spriteRenderer.sortingLayerName = roomName;
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }

        private static void InstatiateTransform(GameObject movmentCurve)
        {
            _target.transform.name = "target" + _idTarget.ToString();
            _target.transform.position = movmentCurve.transform.GetChild(0).position;
            _idTarget++;
        }

    }
}