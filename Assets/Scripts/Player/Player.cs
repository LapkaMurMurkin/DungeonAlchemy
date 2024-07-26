using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Weapon _weapon;

    [SerializeField]
    private Enemy _enemy;

    private InputAction _attack;

    public void Initialize()
    {
        _attack = ServiceLocator.Get<ActionMap>().Fight.Attack;
        _attack.performed += Attack;
        _weapon.OnDamageDeal += SendDamage;
    }

    private void OnDisable()
    {
        _attack.performed -= Attack;
        _weapon.OnDamageDeal -= SendDamage;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        _animator.Play("Attack");
        Debug.Log("Attack");
    }

    private void SendDamage(int damage)
    {
        _enemy.ReceiveDamage(damage);
        Debug.Log("SendDamage");
        Debug.Log(damage);
    }
}
