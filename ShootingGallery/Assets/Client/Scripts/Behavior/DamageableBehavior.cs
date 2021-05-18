using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBehavior : MonoBehaviour, IDamageable
{
    public void HitTarget(ITarget target)
    {
        FindObjectOfType<AudioManager>().Play(Helper.Audio[Helper.TagName.AmongDeathSound]);
        if(target.GetScore()<0)
            FindObjectOfType<AudioManager>().Play(Helper.Audio[Helper.TagName.MistakeShotSound]);
        Player.UpdateScore(target.GetScore());
        target.SetIsLive(false);
        Destroy(target.GetTarget());
    }

    public void DisappearTarget(ITarget target)
    {
        target.SetIsLive(false);
        Destroy(target.GetTarget());
    }
}
