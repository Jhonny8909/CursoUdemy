using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _powerUp;
    [SerializeField] GameObject _enemyContainer;
    [SerializeField] GameObject _powerUpContainer;
    [SerializeField] float _cooldownSpawn = 5f;
    bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7f, 0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_cooldownSpawn);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7f, 0f);
            GameObject newPowerUp = Instantiate(_powerUp, posToSpawn, Quaternion.identity);
            newPowerUp.transform.parent = _powerUpContainer.transform;
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
