using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackDuration;
    [SerializeField] float cooldown;
    [SerializeField] ParticleSystem attackEffect;
    [SerializeField] GameObject attackHitbox;

    bool attacking;

    void Start()
    {
        attackHitbox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)
            StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        attacking = true;
        attackHitbox.SetActive(true);
        attackEffect.Play();
        yield return new WaitForSeconds(attackDuration);
        attackHitbox.SetActive(false);
        yield return new WaitForSeconds(cooldown);
        attacking = false;
    }
}