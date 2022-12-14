using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Healthbar hpBar;

    [Header("Entity Variables")]
    [field: SerializeField] protected float hp;
    [field: SerializeField] protected float maxHP;
    [field: SerializeField] protected float damage;

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

    public virtual void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Die();
            return;
        }
    }
    protected abstract void Attack(Entity entity);
    protected abstract void MoveTo(Vector3 point);
    protected abstract void Die();
}
