using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }
    private void Update()
    {
        WeaponBobLoop();
        AttackLoop();
    }
    
    private void WeaponBobLoop()
    {
        animator.SetBool("Walking", Player.Instance.Moving);
    }
    
    void AttackLoop()
    {
        var mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
            Attack();
    }
}
