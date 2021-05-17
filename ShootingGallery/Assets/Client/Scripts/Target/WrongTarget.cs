using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Targets
{
    public class WrongTarget : Target
    {
        public WrongTarget(GameObject target, GameObject movmentTrajectory) : base(target, movmentTrajectory, -1)
        {
            _target.GetTarget().transform.position = _movable.StartPoint(_target.GetTarget().transform.position);
        }

        protected override void InitBehaviors(GameObject target, GameObject movmentTrajectory, int score)
        {
            _damageable = new DamageableBehavior();
            _target = new TargetBehavior(target, _damageable.HitTarget, score);
            _movable = new MoveBezierCurveBehavior(_target, _damageable.DisappearTarget, movmentTrajectory);
        }
    }
}
