using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Targets
{
    public class NeutralTarget : Target
    {
        public NeutralTarget(GameObject target, GameObject movmentTrajectory) : base(target, movmentTrajectory)
        {
            rewardScore = 0;
        }
        protected override void InitBehaviors()
        {
            _movable = new MoveBezierCurveBehavior(_movmentTrajectory);
            _damageable = new NonDamageableBehavior();
        }
    }
}
