using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [field: SerializeField] public float HP { get; protected set; }
    [field: SerializeField] public float MaxHP { get; protected set; }
    [field: SerializeField] public float Damage { get; protected set; }
    [SerializeField] protected Healthbar HpBar;

    protected void Awake()
    {
        HpBar.Set(HP, MaxHP);
    }

    public virtual void GetDamage(float damage)
    {
        HP -= damage;
        HpBar.Set(HP, MaxHP);
        if (HP <= 0)
        {
            HP = 0;
            Die();
            return;
        }
    }
    protected abstract void Attack(Entity entity);
    protected abstract void MoveTo(Vector3 point);
    protected abstract void Die();
}
