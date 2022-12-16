using System;
using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    public static Action OnDie;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private EntityConfig startConfig;

    private void Update()
    {
        if ((Player.Instance.transform.position - transform.position).sqrMagnitude > attackRange)
        {
            Move();
            return;
        }
        Attack(Player.Instance);
    }

    protected override void Move()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        transform.position += direction * walkSpeed * Time.deltaTime;
    }

    protected override void Attack(Entity entity)
    {
        if (!canAttack) return;
        Player.Instance.GetDamage(damage);
        canAttack = false;
    }

    protected override void Die()
    {
        StopCoroutine(AttackTimer());
        OnDie();
        gameObject.SetActive(false);
    }

    private void GetConfigVariables()
    {
        float enemyLevel = 1 + AIDirector.Instance.DifficultMultiply;
        HP = startConfig.HP * enemyLevel;
        MaxHP = startConfig.MaxHP * enemyLevel;
        damage = startConfig.Damage * enemyLevel;
        walkSpeed = startConfig.WalkSpeed * enemyLevel;
        attackFrequency = startConfig.AttackFrequency * enemyLevel;
    }

    private void OnEnable()
    {
        GetConfigVariables();
        StartCoroutine(AttackTimer());
    }

    private void OnDisable()
    {
        StopCoroutine(AttackTimer());
    }
}
