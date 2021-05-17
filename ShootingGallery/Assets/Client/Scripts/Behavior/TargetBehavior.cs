using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class TargetBehavior : MonoBehaviour, ITarget
    {
        private GameObject _target;
        private float _speed;
        private int _rewardScore = 0;
        private bool _isLive;

        public UnityEvent HitEvent;
        public DeadHandler OnTargetKill;
 
        public TargetBehavior(GameObject target, DeadHandler onTargetKill, int rewardScore)
        {
            OnTargetKill = onTargetKill;
            _target = target;
            _rewardScore = rewardScore;
            _speed = Random.Range(0.3f, 0.6f);
            _isLive = true;
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public bool GetIsLive()
        {
            return _isLive;
        }

        public void SetIsLive(bool isLive)
        {
            _isLive = isLive;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public int GetScore()
        {
            return _rewardScore;
        }

        public void ApplyDamage()
        {
            if (_isLive)
            {
                OnTargetKill?.Invoke(this);
                //HitEvent.Invoke();
            }
        }
    }
}
