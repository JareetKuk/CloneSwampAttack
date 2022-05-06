using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private float _attackDelay;
    private float _lastAttackTime;
    private Animator _animator;
    private void Start() {
        _animator = GetComponent<Animator>();
    }
    private void Update() {
        if(_lastAttackTime <= 0){
            _animator.Play("Attack");
            if(_lastAttackTime + _attackDelay <= 0){
                Attack(Target);
                _lastAttackTime = _delay;
            }
        }
        _lastAttackTime -= Time.deltaTime;
    }
    private void Attack(Player target){
            target.ApplyDamage(_damage);
    }
}
