using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public float Damage;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy potentialEnemy = collision.gameObject.GetComponent<Enemy>();
        if (potentialEnemy != null)
        {
            potentialEnemy.GetDamage(Damage);
            gameObject.SetActive(false);
        }
    }
}