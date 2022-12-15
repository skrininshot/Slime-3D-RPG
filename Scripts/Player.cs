using UnityEngine;

public class Player : Entity
{
    public static Player Instance;
    [Header("Skills")]
    [SerializeField] protected SkillInfo damageSkill;
    [SerializeField] protected SkillInfo maxHPSkill;
    private bool fighting;

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

    private void EnemyCountChanged(int enemyCount)
    {
        fighting = (enemyCount > 0);
    }

    private void Update()
    {
        if (!fighting)
        {
            Move();
        }
        else
        {
            
        }
    }

    private void Move()
    {
        LevelPanels.Instance.Move(walkSpeed);
    }

    protected override void Attack(Entity entity)
    {
        
    }

    protected override void Die()
    {
        
    }

    private void OnEnable()
    {
        Instance = this;
        SkillArticleUI.OnUpgrade += UpdateSkills;
        AIDirector.OnEnemyCountChanged += EnemyCountChanged;
    }

    private void OnDisable()
    {
        SkillArticleUI.OnUpgrade -= UpdateSkills;
        AIDirector.OnEnemyCountChanged -= EnemyCountChanged;
    }

}
