using Assets.Client.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehavior : IDamageable
{
    //public UnityEvent OnHitTarget;
    public void HitTarget(int score)
    {
       // OnHitTarget.Invoke(score);
        Player.Score += score;
    }
}
