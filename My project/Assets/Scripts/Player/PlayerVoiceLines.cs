using UnityEngine;
using System.Collections;

public class PlayerVoiceLines : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] voiceLines;
    [SerializeField] float minInterval;
    [SerializeField] float maxInterval;

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        StartCoroutine(PlayVoiceLines());
    }

    IEnumerator PlayVoiceLines()
    {
        while (true)
        {
            float wait = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(wait);

            if (!playerHealth.isDead && voiceLines.Length > 0)
            {
                AudioClip clip = voiceLines[Random.Range(0, voiceLines.Length)];
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
