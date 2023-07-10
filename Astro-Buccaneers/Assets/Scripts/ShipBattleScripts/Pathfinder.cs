using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();

        // Check if the current scene is "ShipBattleScene"
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "ShipBattleScene")
        {
            // Initialize the necessary variables
            waveConfig = enemySpawner.GetCurrentWave();
            waypoints = waveConfig.GetWaypoints();
            transform.position = waypoints[waypointIndex].transform.position;
        }
        else
        {
            // If the scene is not "ShipBattleScene", disable the script
            enabled = false;
        }
    }

    void Update()
    {
        // Only follow the path if the script is enabled
        if (enabled)
        {
            FollowPath();
        }
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
