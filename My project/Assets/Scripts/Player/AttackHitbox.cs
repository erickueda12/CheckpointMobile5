using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField] int damage;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip enemyHitSound;

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            audioSource.PlayOneShot(enemyHitSound);
        }
    }
}