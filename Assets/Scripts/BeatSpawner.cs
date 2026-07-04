using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    
    public AudioSource musicSource;
    public GameObject obstaclePrefab;
    public Transform spawnPoint;
    public float bpm = 120f;
    public float beatOffset = 0f;

    public int[] spawnPattern = { 0, 0, 1, 0, 1, 0 };

    public bool canSpawn = true;

    private float beatInterval;
    private float nextBeatTime;
    private float previousTime;
    private int beatIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = beatInterval + beatOffset;
        previousTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = musicSource.time;

        //detects music loop restart
        if (currentTime < previousTime)
        {
            nextBeatTime = beatInterval + beatOffset;
            beatIndex = 0;
        }

        if (currentTime >= nextBeatTime)
        {
            if (canSpawn && spawnPattern[beatIndex] == 1)
            {
                SpawnObstacle();
            }

            beatIndex++;
            if (beatIndex >= spawnPattern.Length)
            {
                beatIndex = 0;
            }
            nextBeatTime += beatInterval;
        }

        previousTime = currentTime;
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
    }
}