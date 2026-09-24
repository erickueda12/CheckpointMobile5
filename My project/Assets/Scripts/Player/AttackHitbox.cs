using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] int damage;

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
            enemy.TakeDamage(damage);
    }
}