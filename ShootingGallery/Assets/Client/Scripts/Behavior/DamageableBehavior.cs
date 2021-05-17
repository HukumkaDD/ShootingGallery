using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehavior : MonoBehaviour, IDamageable
{
    public void HitTarget(ITarget target)
    {
        Player.UpdateScore(target.GetScore());
        //target.GetHitAudio().Play();
        target.SetIsLive(false);
        Destroy(target.GetTarget());
    }

    public void DisappearTarget(ITarget target)
    {
        target.SetIsLive(false);
        Destroy(target.GetTarget());
    }
}
