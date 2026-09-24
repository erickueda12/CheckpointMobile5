using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject normalEnemy;
    [SerializeField] GameObject fastEnemy;
    [SerializeField] GameObject tankEnemy;

    public GameObject CreateEnemy(EnemyType type, Vector3 position)
    {
        switch (type)
        {
            case EnemyType.Basic:
                return Instantiate(normalEnemy, position, Quaternion.identity);

            case EnemyType.Fast:
                return Instantiate(fastEnemy, position, Quaternion.identity);

            case EnemyType.Tank:
                return Instantiate(tankEnemy, position, Quaternion.identity);

            default:
                return null;
        }
    }
}
