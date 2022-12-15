using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Entity Settigs")]
public class EntityConfig : ScriptableObject
{
    [SerializeField] private float hp;
    [SerializeField] private float maxHP;
    [SerializeField] private float damage;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float attackFrequency;

    public float HP => hp;
    public float MaxHP => maxHP;
    public float Damage => damage;
    public float WalkSpeed => walkSpeed;
    public float AttackFrequency => attackFrequency;
}
