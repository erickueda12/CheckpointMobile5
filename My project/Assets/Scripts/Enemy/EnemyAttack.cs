using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float attackCooldown;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip attackSound;

    private float nextAttackTime;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    audioSource.PlayOneShot(attackSound);
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }
}
