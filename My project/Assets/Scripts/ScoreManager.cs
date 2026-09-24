using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    private int score;

    void OnEnable()
    {
        EnemyHealth.OnEnemyDied += AddScore;
    }

    void OnDisable()
    {
        EnemyHealth.OnEnemyDied -= AddScore;
    }

    void AddScore()
    {
        score++;
        scoreText.text = "Pontos: " + score;
    }
}
