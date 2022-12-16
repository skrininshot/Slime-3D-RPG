using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public float Damage;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy potentialEnemy = other.gameObject.GetComponent<Enemy>();
        if (potentialEnemy != null)
        {
            potentialEnemy.GetDamage(Damage);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
