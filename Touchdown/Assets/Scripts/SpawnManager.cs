using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPos;
    [SerializeField]
    private Transform _spawnPos_two;

    [SerializeField]
    private Transform _spawnPos_three;

    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _ballContainer;

    [SerializeField]
    private GameObject _ballPrefab;

    public bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnRoutineBall());
        StartCoroutine(SpawnRoutineBall_two());
        StartCoroutine(SpawnRoutineBall_three());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false){
            Vector3 spawn = new Vector3(1.5f, 0.406f, 1.3f);

            GameObject newEnemy = Instantiate(_enemyPrefab, spawn, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    IEnumerator SpawnRoutineBall()
    {
        while (_stopSpawning == false){
            GameObject ball = Instantiate(_ballPrefab, _spawnPos.position, Quaternion.identity);
            ball.transform.SetParent(_ballContainer.transform);
            yield return new WaitForSeconds(Random.Range(6f, 9f));
        }
    }

    IEnumerator SpawnRoutineBall_two()
    {
        while (_stopSpawning == false){
            GameObject ball = Instantiate(_ballPrefab, _spawnPos_two.position, Quaternion.identity);
            ball.transform.SetParent(_ballContainer.transform);
            yield return new WaitForSeconds(Random.Range(3f, 7f));
        } 
    }   

    IEnumerator SpawnRoutineBall_three()
    {
        while (_stopSpawning == false){
            GameObject ball = Instantiate(_ballPrefab, _spawnPos_three.position, Quaternion.identity);
            ball.transform.SetParent(_ballContainer.transform);
            yield return new WaitForSeconds(Random.Range(4f, 8f));
        } 
    }

public void OnPlayerDeath(){
        _stopSpawning = true;
    }

}
