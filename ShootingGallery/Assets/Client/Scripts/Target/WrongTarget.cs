using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Targets
{
    public class WrongTarget : Target
    {
        public WrongTarget(GameObject target, GameObject movmentTrajectory) : base(target, movmentTrajectory)
        {
            rewardScore = -1;
        }

        protected override void InitBehaviors()
        {
            _movable = new MoveBezierCurveBehavior(_movmentTrajectory);
            _damageable = new DamageableBehavior();
        }
    }
}
