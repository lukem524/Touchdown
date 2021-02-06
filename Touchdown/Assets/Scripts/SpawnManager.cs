using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bombPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _ballContainer;

    [SerializeField]
    private GameObject _ballPrefab;

    [SerializeField]
    private GameObject _proteinShake;

    [SerializeField]
    public bool _stopSpawning = false;


    // Start is called before the first frame update
    void Start()
    {
        //calling all the coroutine so the objects can start spawning
        StartCoroutine(SpawnRoutineEnemy());
        StartCoroutine(SpawnRoutineBall());
        StartCoroutine(SpawnRoutineBomb());
        StartCoroutine(SpawnRoutinePowerup());
        }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerDeath(){
        _stopSpawning = true;
    }
//creating a coroutine to spawn the enemy.
    IEnumerator SpawnRoutineEnemy()
    {
        while (_stopSpawning == false){
            //wait for one second before starting to spawn. 
            yield return new WaitForSeconds(1);
            //set the position of spawning
            Vector3 spawn = new Vector3(1.5f, 1.3f, 1.3f);
            //spawning the object. 
            GameObject newEnemy = Instantiate(_enemyPrefab, spawn, Quaternion.identity);
            newEnemy.transform.SetParent(_enemyContainer.transform);
            //wait between 1 and 3 seconds before spawning this object again.
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
//creating a coroutine to spawn balls.
    IEnumerator SpawnRoutineBall()
    {
        while (_stopSpawning == false){
            //setting the position where the balls needs to spawn. 
            Vector3 _posToSpawn = new Vector3(Random.Range(-1.1f, 0.5f), Random.Range(1f, 1.4f), 1.3f);
            //spawning the object.
            GameObject _ball = Instantiate(_ballPrefab, _posToSpawn, Quaternion.identity);
            _ball.transform.SetParent(_ballContainer.transform);
            //wait between 2 to 4 seconds before spawning other balls.
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
        
        }
//creating a coroutine to spawn the bombs.
    IEnumerator SpawnRoutineBomb(){
            while (_stopSpawning == false){
                 //wait for 2 seconds before starting spawning bombs.
                yield return new WaitForSeconds(2);
                 //setting the position where the bomb needs to spawn
                Vector3 _postoSpawn = new Vector3(1.6f, Random.Range(1f, 1.4f), 1.3f);
                 //spawning the bomb
                GameObject _newBomb = Instantiate(_bombPrefab, _postoSpawn, Quaternion.identity);
                 //wait for 3 seconds before spawning another bomb.
                yield return new WaitForSeconds(3f);
            }
        }

        IEnumerator SpawnRoutinePowerup(){
            while (_stopSpawning == false){
                yield return new WaitForSeconds(5f);
                Vector3 _postoSpawn = new Vector3(Random.Range(-0.7f, 0.2f), 0.5f, 1.3f);
                GameObject _Powerup = Instantiate(_proteinShake, _postoSpawn, Quaternion.identity);
                yield return new WaitForSeconds(10f);
            }
        }
}
