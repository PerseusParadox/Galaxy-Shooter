using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool gameOver = true;
    public GameObject player;
    UIManager _uimanager;
    SpawnManager spawnManager;
    

    private void Start () {
        _uimanager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
        spawnManager = GameObject.Find ("SpawnManager").GetComponent<SpawnManager> ();
        
    }
    void Update () {
        //if game over is true
        //if space key is pressed
        //hide main menu
        //Spawn Player
        //game over is false
        if ( gameOver ) {
            if ( Input.GetKeyDown (KeyCode.Space) ) {
                _uimanager.HideTitleScreen ();
                Instantiate (player , Vector3.zero , Quaternion.identity);
                gameOver = false;
                StartCoroutine (spawnManager.PowerupsSpawnRoutine());
                StartCoroutine (spawnManager.SpawnEnemy ());
            }
        }
        
    }
}
