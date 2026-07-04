using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.isGameplayActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timerText.text = "Time: " + timer.ToString("F2");

        
    }
}
