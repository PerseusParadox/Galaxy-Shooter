using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    int powerupID; //0 triple, 1 speed, 2 shield
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.Translate (Vector3.down * Time.deltaTime * _speed);
        if ( transform.position.y < -5.1 ) {
            Destroy (this.gameObject);
        }

    }

    private void OnTriggerEnter2D (Collider2D other) {
        if ( other.tag == "Player" ) {
            
            Player player = other.GetComponent<Player> (); //handle

            if ( player != null ) {   //Double Check, preferable if you don't wanna have errors in the future
                if ( powerupID==0 ) {
                    player.TripleShotPowerupOn ();
                    
                } else if ( powerupID==1 ) {
                    player.SpeedBoostOn ();
                } else if ( powerupID ==2 ) {
                    player.shieldActive = true;
                }

                
            }
            Destroy (this.gameObject);
        }
        
    }
}
