using UnityEngine;

public class Player : Entity
{
    [SerializeField] private Skill damage;
    [SerializeField] private Skill maxHP;

    private void UpdateSkills()
    {
        Damage = damage.points;
        MaxHP = maxHP.points;
        HpBar.Set(HP, MaxHP);
    }

    protected override void Attack(Entity entity)
    {
        
    }

    protected override void MoveTo(Vector3 point)
    {

    }

    protected override void Die()
    {
        
    }

    private void OnEnable()
    {
        SkillArticleUI.OnUpgrade += UpdateSkills;
    }

    private void OnDisable()
    {
        SkillArticleUI.OnUpgrade -= UpdateSkills;
    }

}
