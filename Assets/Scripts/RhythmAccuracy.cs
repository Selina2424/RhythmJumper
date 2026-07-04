using UnityEngine;

public class RhythmAccuracy : MonoBehaviour
{
    public AudioSource musicSource;
    public float bpm = 120f;

    public float lastJumpAccuracy;

    private float beatInterval;
    private float totalAccuracy = 0f;
    private int jumpCount = 0;

    public float averageAccuracy = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatInterval = 60f / bpm;
    }
    public void CheckJumpAccuracy()
    {
        if (!GameManager.instance.isGameplayActive)
        {
            return;
        }

        float songTime = musicSource.time;
        float nearestBeat = Mathf.Round(songTime / beatInterval) * beatInterval;
        float offset = Mathf.Abs(songTime - nearestBeat);

        float maxOffset = beatInterval / 2f;
        float accuracy = 1f - (offset / maxOffset);

        //avoids negatives
        accuracy = Mathf.Clamp01(accuracy);

        lastJumpAccuracy = offset;

        totalAccuracy += accuracy;
        jumpCount++;
        averageAccuracy = totalAccuracy / jumpCount;




        Debug.Log("Jump offset: " + offset.ToString("F3"));
        Debug.Log("Jump accuracy: " + (accuracy * 100f).ToString("F1") + "%");
        Debug.Log("Average beat accuracy: " + (averageAccuracy * 100f).ToString("F1") + "%");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
