using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDamageableBehavior :MonoBehaviour, IDamageable
{
    public void HitTarget(ITarget target)
    {
    }
    public void DisappearTarget(ITarget target)
    {
        target.SetIsLive(false);
        Destroy(target.GetTarget());
    }
}
