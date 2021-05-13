using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Rooms;

namespace Targets
{
    public abstract class Target
    {
        public GameObject gameObject;

        public Target(Room roomNumber)
        {
            gameObject = RoomsManager.GetPosition(roomNumber);
        }

        public void SpawnTarget()
        {
        }

        public void DestroyTarget()
        {

        }

        public void MoveTarget()
        {

        }

    }
}
