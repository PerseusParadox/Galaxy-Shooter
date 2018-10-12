using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float _laserSpeed = 20f;
    public int laserID;
    void Update () {

        transform.Translate (0f , _laserSpeed * Time.deltaTime , 0f);
        //when bool is checked fire tripe shot
        if ( transform.position.y > 7 ) {
            Destroy (this.gameObject);
        }
    }
    
}
