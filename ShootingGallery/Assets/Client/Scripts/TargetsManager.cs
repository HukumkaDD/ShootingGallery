using System.Collections;
using System.Collections.Generic;
using System;
using Rooms;
using UnityEngine;

namespace Targets
{
    public static class TargetManager
    {
        public static Target CreateTarget(Room roomNumber, int evilChance, int goodChance, int neutralChance)
        {
            System.Random rnd = new System.Random();
            int target = rnd.Next(0, evilChance + goodChance + neutralChance);

            if (target <= evilChance)
                return new EvilTarget(roomNumber);
            else if (target > evilChance && target < evilChance + goodChance)
                return new GoodTarget(roomNumber);
            else
                return new NeutralTarget(roomNumber);
        }
    }
}