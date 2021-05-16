using UnityEngine;

public interface IMovable
{
    Vector3 Move(Vector3 currentPosition, float currentTime);

    Vector3 StartPoint();
}
