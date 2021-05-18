using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDamageableBehavior :MonoBehaviour, IDamageable
{
    public void HitTarget(ITarget target)
    {
        FindObjectOfType<AudioManager>().Play(Helper.Audio[Helper.TagName.RicochetSound]);
    }
    public void DisappearTarget(ITarget target)
    {
        target.SetIsLive(false);
        Destroy(target.GetTarget());
    }
}
