using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public bool hasTheGameStarted;
    [SerializeField]
    private GameObject enemyShip;
    [SerializeField]
    private GameObject[] powerups;
    [SerializeField]
    private float powerupSpawnFrequency = 5;
    [SerializeField]
    private GameObject player;
    GameManager _gameManager;
    private void Start () {
        _gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }

    private void Update () {
        hasTheGameStarted = _gameManager.gameOver;
        
    }


    public IEnumerator SpawnEnemy () {
        while ( true ) {
            Instantiate (enemyShip , new Vector3 (Random.Range (-8f , 8f) , 5.3f , 0f) , Quaternion.identity);
            yield return new WaitForSeconds (5);
        }
    }
    public IEnumerator PowerupsSpawnRoutine () {
        while ( true) {
            int randomPowerup = Random.Range (0 , 3);
            Instantiate (powerups[randomPowerup] , new Vector3 (Random.Range (-8f , 8f) , 5.3f , 0f) , Quaternion.identity);
            yield return new WaitForSeconds (powerupSpawnFrequency);
        }


    }
}
