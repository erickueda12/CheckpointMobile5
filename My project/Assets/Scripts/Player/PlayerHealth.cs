using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Audio;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] int maxHealth;

    [Header("Game Over Ragdoll")]
    [SerializeField] float upForceDie;
    [SerializeField] float frontForceDie;
    [SerializeField] float rotationForceDie;

    [Header ("UI Settings")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject gameOverPanel;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip introSound;
    [SerializeField] AudioClip deathScreamSound;
    [SerializeField] AudioClip fatalHitSound;

    public bool isDead;

    private int currentHealth;

    private Rigidbody rb;
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    void Start()
    {
        currentHealth = maxHealth;

        audioSource.PlayOneShot(introSound, 0.7f);

        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();

        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }

        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }

    void Die()
    {
        playerMovement.enabled = false;
        playerAttack.enabled = false;

        audioSource.PlayOneShot(deathScreamSound);
        audioSource.PlayOneShot(fatalHitSound);

        rb.constraints = RigidbodyConstraints.None;

        rb.AddForce(Vector3.up * upForceDie + transform.forward * frontForceDie, ForceMode.Impulse);
        rb.AddTorque(transform.right * rotationForceDie, ForceMode.Impulse);
        StartCoroutine(ShowGameOver());
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(2f);

        gameOverPanel.SetActive(true);
    }
}
