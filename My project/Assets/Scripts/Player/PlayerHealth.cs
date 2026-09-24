using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] int maxHealth;

    [Header("Game Over Ragdoll")]
    [SerializeField] float upForceDie;
    [SerializeField] float frontForceDie;
    [SerializeField] float rotationForceDie;

    [Header ("UI Settings")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject gameOverPanel;

    private int currentHealth;

    private Rigidbody rb;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    void Start()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();

        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
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
