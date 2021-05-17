using UnityEngine;

public interface IDamageable
{
    void HitTarget(ITarget target);

    void DisappearTarget(ITarget target);
}
