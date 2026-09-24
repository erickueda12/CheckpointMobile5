using UnityEngine;
using TMPro;

public class ComboManager : MonoBehaviour
{
    [SerializeField] TMP_Text styleText;
    [SerializeField] TMP_Text comboText;
    [SerializeField] float comboTime;

    private Vector3 originalPosition;
    private int combo;
    private float comboTimer;

    void OnEnable()
    {
        EnemyHealth.OnEnemyDied += AddCombo;
    }

    void OnDisable()
    {
        EnemyHealth.OnEnemyDied -= AddCombo;
    }
    private void Awake()
    {
        styleText.gameObject.SetActive(false);
    }

    private void Start()
    {
        originalPosition = styleText.transform.localPosition;
    }

    void Update()
    {
        if (combo > 0)
        {
            comboTimer -= Time.deltaTime;

            float timeLeft = comboTimer / comboTime;

            if (timeLeft < 0.5f)
            {
                float intensity = (1f - timeLeft) * 5f;

                float x = Random.Range(-intensity, intensity);
                float y = Random.Range(-intensity, intensity);

                Vector3 shake = new Vector3(x, y, 0f);

                styleText.transform.localPosition = originalPosition + shake;
            }
            else
            {
                styleText.transform.localPosition = originalPosition;
            }

            if (comboTimer <= 0f)
            {
                combo = 0;

                styleText.transform.localPosition = originalPosition;

                styleText.gameObject.SetActive(false);
            }

            float hue = Mathf.Repeat(Time.time * 0.5f, 1f);

            styleText.color = Color.HSVToRGB(hue, 1f, 1f);
            comboText.color = Color.HSVToRGB(hue, 1f, 1f);
        }
    }

    void AddCombo()
    {
        combo++;
        comboTimer = comboTime;

        if (combo >= 50)
        {
            styleText.text = "S";
        }
        else if (combo >= 25)
        {
            styleText.text = "A";
        }
        else if (combo >= 10)
        {
            styleText.text = "B";
        }
        else if (combo >= 5)
        {
            styleText.text = "C";
        }
        else
        {
            styleText.text = "D";
        }

        comboText.text = "Combo: " + combo;
        styleText.gameObject.SetActive(true);
    }
}