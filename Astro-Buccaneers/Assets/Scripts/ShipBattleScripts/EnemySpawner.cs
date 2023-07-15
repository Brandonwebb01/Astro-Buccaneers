using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipBattleScripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<WaveConfig> waveConfigs;
        [SerializeField] float timeBetweenWaves = 0f;
        [SerializeField] bool isLooping;
        WaveConfig currentWave;

        private bool enemyShipExists = true;
        private List<GameObject> spawnedEnemies = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemyWaves());
        }

        public WaveConfig GetCurrentWave()
        {
            return currentWave;
        }

        IEnumerator SpawnEnemyWaves()
        {
            do
            {
                foreach (WaveConfig wave in waveConfigs)
                {
                    currentWave = wave;
                    for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                    {
                        if (!enemyShipExists)
                        {
                            // Break out of nested loops and exit coroutine
                            isLooping = false;
                            yield break;
                        }

                        GameObject enemy = Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWayPoint().position,
                            Quaternion.identity,
                            transform);

                        spawnedEnemies.Add(enemy);

                        yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    }
                    yield return new WaitForSeconds(timeBetweenWaves);
                }
            }
            while (isLooping);
        }

        public void OnEnemyShipDestroyed(string enemyShipName)
        {
            if (enemyShipName == "EnemyShip")
            {
                enemyShipExists = false;

                // Clear the spawned enemies
                ClearSpawnedEnemies();
            }
        }

        private void ClearSpawnedEnemies()
        {
            foreach (GameObject enemy in spawnedEnemies)
            {
                Destroy(enemy);
            }

            spawnedEnemies.Clear();
        }
    }
}
