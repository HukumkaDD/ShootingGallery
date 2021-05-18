using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace Targets
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Target
    {
        public GameObject TargetGameObject
        {
            get
            {
                return _target.GetTarget();
            }

            set
            {
                _target.SetTarget(value);
            }
        }
        public bool IsTargetLive
        {
            get
            {
                return _target.GetIsLive();
            }
        }

        protected IMovable _movable;
        protected IDamageable _damageable;
        protected ITarget _target;

        protected abstract void InitBehaviors(GameObject target, GameObject movmentTrajectory, int score);

        public Target(GameObject target, GameObject movmentTrajectory, int score)
        {
            InitBehaviors(target, movmentTrajectory, score);
        }

        public void MoveTarget()
        {
            if (TargetGameObject != null)
                TargetGameObject.transform.position = _movable.Move(TargetGameObject.transform.position, _target.GetSpeed());
        }

        public void Hit()
        {
            _target.ApplyDamage();
        }

    }
}
