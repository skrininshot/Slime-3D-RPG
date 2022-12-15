using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Healthbar hpBar;

    [Header("Entity Variables")]
    [field: SerializeField] protected float hp;
    [field: SerializeField] protected float maxHP;
    [field: SerializeField] protected float damage;
    [field: SerializeField] protected float walkSpeed;
    [field: SerializeField] protected float attackFrequency;

    public float HP
    {
        get { return hp; }
        protected set
        {
            hp = value;
            hpBar.Set(hp, maxHP);
        }
    }
    public float MaxHP
    {
        get { return maxHP; }
        protected set
        {
            maxHP = value;
            hpBar.Set(hp, maxHP);
        }
    }
    public float Damage => damage;
    public float WalkSpeed => walkSpeed;
    public float AttackFrequency => attackFrequency;

    protected bool canAttack = true;

    public virtual void GetDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            Die();
            return;
        }
    }
    protected abstract void Attack(Entity entity);
    protected abstract void Die();

    protected IEnumerator AttackTimer()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1f / attackFrequency);
        while (true)
        {
            yield return wait;
            canAttack = true;
        }
    }
}
