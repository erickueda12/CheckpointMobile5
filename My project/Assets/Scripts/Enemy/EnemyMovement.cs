using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
}
