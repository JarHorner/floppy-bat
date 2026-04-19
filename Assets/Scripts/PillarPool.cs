using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarPool : MonoBehaviour
{
    [SerializeField] private GameObject regularPillarPrefab;
    [SerializeField] private GameObject smallerPillarPrefab;
    private GameObject[] pillars;
    private Vector2 objectPoolPosition = new Vector2 (-15, -25f);
    [SerializeField] private int pillarPoolSize = 5;
    [SerializeField] private float spawnRate;
    [SerializeField] private float regColumnMin = -1f;
    [SerializeField] private float regColumnMax = 3.5f;
    [SerializeField] private float smallColumnMin = -1f;
    [SerializeField] private float smallColumnMax = 3.5f;
    private float timeSinceLastSpawned = 0f;
    private float spawnXPosition = 15f;
    private int currentPillar = 0;
    private int numReplacedPillars = 0;

    void Start()
    {
        pillars = new GameObject[pillarPoolSize];
        //ensures the spawn of first pillar when starting the game
        timeSinceLastSpawned = spawnRate;
        for (int i = 0; i < pillarPoolSize; i++)
        {
            pillars[i] = (GameObject)Instantiate(regularPillarPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        if (GameController.instance.jumped)
        {
            timeSinceLastSpawned += Time.deltaTime;
            if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
            {
                timeSinceLastSpawned = 0f;
                if (GameController.instance.scoreNum < 16)
                {
                    float spawnYPosition = Random.Range(regColumnMin, regColumnMax);
                    pillars[currentPillar].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                    currentPillar++;
                }
                else
                {
                    if (numReplacedPillars < 5)
                    {
                        numReplacedPillars++;
                        Destroy(pillars[currentPillar]);
                        pillars[currentPillar] = (GameObject)Instantiate(smallerPillarPrefab, objectPoolPosition, Quaternion.identity);
                    }
                    float spawnYPosition = Random.Range(smallColumnMin, smallColumnMax);
                    pillars[currentPillar].transform.position = new Vector2(spawnXPosition, spawnYPosition);
                    currentPillar++;
                }

                if (currentPillar >= pillarPoolSize)
                {
                    currentPillar = 0;
                }
            }
        }

        if (GameController.instance.scoreNum % 4 == 0 && GameController.instance.scoreNum >= 4)
        {
            ChangeSpawnRate();
        }
    }

    private void ChangeSpawnRate()
    {
        if (GameController.instance.scoreNum == 4)
        {
            spawnRate = 1.85f;
        }
        else if (GameController.instance.scoreNum == 8)
        {
            spawnRate = 1.6f;
        }
        else if (GameController.instance.scoreNum == 12)
        {
            spawnRate = 1.45f;
        }
        if (GameController.instance.scoreNum == 16)
        {
            spawnRate = 1.25f;
        }
    }
}
