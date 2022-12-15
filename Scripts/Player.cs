using UnityEngine;

public class Player : Entity
{
    public static Player Instance;
    [Header("Skills")]
    [SerializeField] protected SkillInfo damageSkill;
    [SerializeField] protected SkillInfo maxHPSkill;
    [SerializeField] protected SkillInfo attackSpeedSkill;
    [Header("Other")]
    [SerializeField] private Bullet bulletPrefab;
    private Enemy currentEnemy;
    private PoolMono<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new PoolMono<Bullet>(bulletPrefab, 10, transform);
        bulletPool.AutoExpand = true;
        UpdateSkills();
        hp = maxHP;
    }

    private void UpdateSkills()
    {
        damage = damageSkill.Points;
        maxHP = maxHPSkill.Points;
        attackFrequency = attackSpeedSkill.Points;
    }

    private void SetEnemy(Enemy enemy)
    {
        currentEnemy = enemy;
        if (currentEnemy != null)
        {
            StartCoroutine(AttackTimer());
        }
        else
        {
            StopCoroutine(AttackTimer());
        }
    }

    private void Update()
    {
        if (currentEnemy == null)
        {
            Move();
        }
        else
        {
            Attack(currentEnemy);
        }
    }

    private void Move()
    {
        LevelPanels.Instance.Move(walkSpeed);
    }

    protected override void Attack(Entity entity)
    {
        if (!canAttack) return;
        Bullet newBullet = bulletPool.GetFreeElement();
        newBullet.transform.forward = (currentEnemy.transform.position - transform.position).normalized;
        newBullet.Damage = damage;
        canAttack = false;
    }

    protected override void Die()
    {
        
    }

    private void OnEnable()
    {
        Instance = this;
        SkillArticleUI.OnUpgrade += UpdateSkills;
        AIDirector.OnEnemyCountChanged += SetEnemy;
    }

    private void OnDisable()
    {
        SkillArticleUI.OnUpgrade -= UpdateSkills;
        AIDirector.OnEnemyCountChanged -= SetEnemy;
    }

}
