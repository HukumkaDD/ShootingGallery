using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class NeutralTarget : Target
    {
        public NeutralTarget(GameObject target, GameObject movmentTrajectory) : base(target, movmentTrajectory, 0)
        {
            TargetGameObject.transform.position = new Vector3(TargetGameObject.transform.position.x, TargetGameObject.transform.position.y, -1f);
            TargetGameObject.transform.position = _movable.StartPoint(TargetGameObject.transform.position);
        }

        protected override void InitBehaviors(GameObject target, GameObject movmentTrajectory, int score)
        {
            _damageable = new NonDamageableBehavior();
            _target = new TargetBehavior(target, _damageable.HitTarget, score);
            _movable = new MoveBezierCurveBehavior(_target, _damageable.DisappearTarget, movmentTrajectory);
        }

    }
}
