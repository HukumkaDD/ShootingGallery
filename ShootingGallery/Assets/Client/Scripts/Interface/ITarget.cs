using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    GameObject GetTarget();
    void SetTarget(GameObject target);
    int GetScore();
    float GetSpeed();
    bool GetIsLive();
    void SetIsLive(bool isLive);
    void ApplyDamage();

}
