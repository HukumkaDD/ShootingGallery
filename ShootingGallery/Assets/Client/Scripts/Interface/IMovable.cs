using Game;
using UnityEngine;

public interface IMovable
{
    Vector3 Move(Vector3 currentPosition, float speed);

    Vector3 StartPoint(Vector3 currentPosition);
}
