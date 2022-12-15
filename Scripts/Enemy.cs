using System;
using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    public static Action OnDie;
    [SerializeField] private float attackRange = 1.5f;
    private Player player;

    private void Awake()
    {
        player = Player.Instance;
    }

    private void Update()
    {
        if ((player.transform.position - transform.position).sqrMagnitude > attackRange)
        {
            Move();
            return;
        }

        Attack(player);
    }

    private void Move()
    {
        transform.position += (player.transform.position - transform.position).normalized * walkSpeed * Time.deltaTime;
    }

    protected override void Attack(Entity entity)
    {
        if (!canAttack) return;
        player.GetDamage(damage);
        canAttack = false;
    }

    protected override void Die()
    {
        StopCoroutine(AttackTimer());
        OnDie();
    }

    private void OnEnable()
    {
        StartCoroutine(AttackTimer());
    }

    private void OnDisable()
    {
        StopCoroutine(AttackTimer());
    }
}
