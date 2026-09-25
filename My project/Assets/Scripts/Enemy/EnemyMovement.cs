using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody rb;
    private Transform player;
    private PlayerHealth playerHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
        playerHealth = playerObject.GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (player.position - rb.position).normalized;
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(rotation);
        }

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerDied += Stop;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= Stop;
    }

    void Stop()
    {
        enabled = false;
    }
}
