using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] int damage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider enemy in enemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
