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
            _target.GetTarget().transform.position = new Vector3(_target.GetTarget().transform.position.x, _target.GetTarget().transform.position.y, -1f);
            _target.GetTarget().transform.position = _movable.StartPoint(_target.GetTarget().transform.position);
        }

        protected override void InitBehaviors(GameObject target, GameObject movmentTrajectory, int score)
        {
            _damageable = new NonDamageableBehavior();
            _target = new TargetBehavior(target, _damageable.HitTarget, score);
            _movable = new MoveBezierCurveBehavior(_target, _damageable.DisappearTarget, movmentTrajectory);
        }

    }
}
