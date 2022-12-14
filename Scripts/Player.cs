using UnityEngine;

public class Player : Entity
{
    [Header("Skills")]
    [SerializeField] protected SkillInfo damageSkill;
    [SerializeField] protected SkillInfo maxHPSkill;

    private void Awake()
    {
        UpdateSkills();
        hp = maxHP;
    }

    private void UpdateSkills()
    {
        damage = damageSkill.Points;
        maxHP = maxHPSkill.Points;
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
