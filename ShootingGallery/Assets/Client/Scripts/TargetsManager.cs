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
    enum TypeTarget
    {
        rightTarget,
        neutralTarget,
        wrongTarget,
    }
    public static class TargetsManager
    {
        [Range(0, 100)]
        public static int evilChance = 10;
        [Range(0, 100)]
        public static int neutralChance = 2;
        [Range(0, 100)]
        public static int goodChance = 3;

        public static Sprite[] rightSprites = Resources.LoadAll<Sprite>(Helper.Resource[Helper.TagName.RightTarget]);
        public static Sprite[] wrongSprites = Resources.LoadAll<Sprite>(Helper.Resource[Helper.TagName.WrongTarget]);
        public static Sprite[] neutralSprites = Resources.LoadAll<Sprite>(Helper.Resource[Helper.TagName.NeutralTarget]);

        private static GameObject _target = AssetDatabase.LoadAssetAtPath<GameObject>(Helper.Resource[Helper.TagName.TargetPrefab]);
        private static event CreateTypeTarget GenerateTarget;

        public static Target CreateTarget()
        {
            System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

            // Выбираем случайную комнату
            GameObject[] rooms = GameObject.FindGameObjectsWithTag(Helper.Tags[Helper.TagName.Room]);
            GameObject room = rooms.Skip(random.Next(rooms.Length)).First();

            // Определяем маршут цели в выбранной комнате
            GameObject movmentCurve = room.transform.GetChild(random.Next(room.transform.childCount)).gameObject;

            // Определяем тип мишени
            TypeTarget typeTarget = CalculateTypeTarget();

            if (typeTarget == TypeTarget.wrongTarget)
                GenerateTarget = new CreateTypeTarget(CreateRightTarget);
            if (typeTarget == TypeTarget.neutralTarget)
                GenerateTarget = new CreateTypeTarget(CreateNeutralTarget);
            if (typeTarget == TypeTarget.rightTarget)
                GenerateTarget = new CreateTypeTarget(CreateWrongTarget);

            // Создаем мишень
            return GenerateTarget(room.name, movmentCurve);
        }

        private static TypeTarget CalculateTypeTarget()
        {
            System.Random random = new System.Random();
            int targetChance = random.Next(evilChance + goodChance + neutralChance);

            if (targetChance <= evilChance)
                return TypeTarget.wrongTarget;
            if (targetChance > evilChance && targetChance < evilChance + goodChance)
                return TypeTarget.rightTarget;

            return TypeTarget.neutralTarget;

        }

        private static Target CreateRightTarget(string roomName, GameObject movmentCurve)
        {
            _target.transform.position = movmentCurve.transform.GetChild(0).position;
            InstantiateRenderer(rightSprites, roomName);
            return new RightTarget(_target, movmentCurve);
        }

        private static Target CreateNeutralTarget(string roomName, GameObject movmentCurve)
        {
            _target.transform.position = movmentCurve.transform.GetChild(0).position;
            InstantiateRenderer(neutralSprites, roomName);
            return new NeutralTarget(_target, movmentCurve);
        }

        private static Target CreateWrongTarget(string roomName, GameObject movmentCurve)
        {
            _target.transform.position = movmentCurve.transform.GetChild(0).position;
            InstantiateRenderer(wrongSprites, roomName);
            return new WrongTarget(_target, movmentCurve);
        }

        private static void InstantiateRenderer(Sprite[] sprites, string roomName)
        {
            System.Random random = new System.Random();
            var spriteRenderer = _target.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprites.Skip(random.Next(0, sprites.Length - 1)).First();
            spriteRenderer.sortingLayerName = roomName;
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }
}