using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemyPrefab;

    public bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
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
            yield return new WaitForSeconds(Random.Range(1f, 5f));
        }
    }

    public void OnPlayerDeath(){
        _stopSpawning = true;
    }
}
