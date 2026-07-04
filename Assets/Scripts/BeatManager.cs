using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public AudioSource musicSource;
    public float bpm = 120f;
    public BeatIndicator beatIndicator;

    private float beatInterval;
    private float nextBeatTime;
    private float previousTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = beatInterval;
        previousTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = musicSource.time;

        //detect loop restart
        if (currentTime < previousTime)
        {
            nextBeatTime = beatInterval;
        }

        if (currentTime >= nextBeatTime)
        {
            Debug.Log("Beat!");
            if (beatIndicator != null)
            {
                beatIndicator.ShowBeat();
            }
            nextBeatTime += beatInterval;
        }
        

        previousTime = currentTime;
    }
}

