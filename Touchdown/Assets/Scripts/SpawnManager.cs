using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _ballContainer;

    [SerializeField]
    private GameObject _ballPrefab;
    [SerializeField]
    public bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnRoutineBall());    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false){
            yield return new WaitForSeconds(1);
            Vector3 spawn = new Vector3(1.5f, 0.406f, 1.3f);
            GameObject newEnemy = Instantiate(_enemyPrefab, spawn, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    IEnumerator SpawnRoutineBall()
    {
        while (_stopSpawning == false){
            Vector3 _posToSpawn = new Vector3(Random.Range(-1.1f, 0.5f), Random.Range(0.7f, 1f), 1.3f);
            GameObject _ball = Instantiate(_ballPrefab, _posToSpawn, Quaternion.identity);
            _ball.transform.SetParent(_ballContainer.transform);
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

public void OnPlayerDeath(){
        _stopSpawning = true;
    }

}
