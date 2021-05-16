using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

namespace Targets
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Target:MonoBehaviour
    {
        public GameObject TargetGameObject
        {
            get
            {
                return _target;
            }

            set
            {
                _target = value;
            }
        }

        protected IMovable _movable;
        protected IDamageable _damageable;

        protected GameObject _target;
        protected GameObject _movmentTrajectory;
        protected float lifeTime = 0;
        protected int rewardScore = 0;

        protected abstract void InitBehaviors();

        public Target(GameObject target, GameObject movmentTrajectory)
        {
            _target = target;
            _movmentTrajectory = movmentTrajectory;
            InitBehaviors();
            InstantiateTarget(_target);
            _target.transform.position = _movable.StartPoint();
        }

        private void InstantiateTarget(GameObject target)
        {
            _target = Instantiate(target);
           // target.transform.localScale = RoomsManager.GetLocalScale();
        }

        public void MoveTarget()
        {
            _target.transform.position = _movable.Move(_target.transform.position, lifeTime);
            lifeTime += 0.5f*Time.deltaTime;

            //target.transform.position = MovmentManager.Move(movmentTrajectory, target.transform.position, lifeTime);
            // lifeTime += Time.deltaTime;
        }

        public void Hit()
        {
            _damageable.HitTarget(rewardScore);
        }

    }
}
