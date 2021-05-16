using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class RightTarget : Target
    {
        public RightTarget(GameObject target, GameObject movementTrajectory) : base(target, movementTrajectory)
        {
            rewardScore = 1;
        }
        protected override void InitBehaviors()
        {
            _movable = new MoveBezierCurveBehavior(_movmentTrajectory);
            _damageable = new DamageableBehavior();
        }

    }
}
