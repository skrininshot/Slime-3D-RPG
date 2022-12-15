using UnityEngine;

public class Player : Entity
{
    public static Player Instance { get; private set; }
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
            StopAllCoroutines();
            HP = MaxHP;
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
            if (Vector3.Distance(transform.position, transform.position) > 8f) return;
                Attack(currentEnemy);
        }
    }

    protected override void Move()
    {
        LevelPanels.Instance.Move(walkSpeed);
    }

    protected override void Attack(Entity entity)
    {
        if (!canAttack) return;
        Bullet newBullet = bulletPool.GetFreeElement();
        newBullet.transform.position = transform.position;
        newBullet.transform.forward = (currentEnemy.transform.position - transform.position).normalized;
        newBullet.Damage = damage;
        canAttack = false;
    }

    protected override void Die()
    {
        GameManager.Instance.GameOver();
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
