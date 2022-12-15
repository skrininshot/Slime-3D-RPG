using UnityEngine;

public class Enemy : Entity
{
    private Vector3 playerPoint;
    private void Awake()
    {
        playerPoint = Player.Instance.transform.position;
    }

    private void Update()
    {
        if ((playerPoint - transform.position).sqrMagnitude > 0)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.position += (playerPoint - transform.position).normalized * walkSpeed * Time.deltaTime;
    }

    protected override void Attack(Entity entity)
    {

    }

    protected override void Die()
    {

    }
}
