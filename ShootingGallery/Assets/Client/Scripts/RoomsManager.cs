using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rooms
{
    public enum Room
    {
        first = 0,
        second = 1,
        third = 2,
        fourth = 3,
    }

    public static class RoomsManager
    {
       private static GameObject go = new GameObject();
        public static GameObject GetPosition( Room room)
        {
            if(room==Room.third)
            {
                System.Random rnd = new System.Random();
                int point = rnd.Next(0, 3);

                if (point == 0)
                {
                    go.transform.position = new Vector3(-18.51f, -3.87f, 0);
                }
                if (point == 1)
                {
                    go.transform.position = new Vector3(-6.55f, -8.41f, 0);
                }

                if (point == 2)
                {
                    go.transform.position = new Vector3(-0.45f, -2.7f, 0);
                    Vector3 rotation = go.transform.localEulerAngles;
                    rotation.y += 180;
                    go.transform.localEulerAngles = rotation;
                }
            }
            go.transform.localScale = new Vector3(0.15f, 0.15f, 1);
            return go;
        }
    }
}