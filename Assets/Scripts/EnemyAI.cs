using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField]
    private float _speed = 5f;
    public int health = 1000;
    public int damageTaken = 1000;
    [SerializeField]
    public GameObject explosionAnimation;
    public UIManager _uiManager;
    void Start () {
        _uiManager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
    }

    void Update () {
        Movement ();
        if ( health <= 0 ) {
            Die ();
        }
    }

    public void TakeDamage (int damage) {

        health -= damage;

    }
    void Movement () {
        transform.Translate (Vector3.down * _speed * Time.deltaTime);

        if ( transform.position.y < -6.4f ) {
            transform.position = new Vector3 (Random.Range (-7.7f , 7.7f) , 6.4f , 0f);
        }
    }
    private void OnTriggerEnter2D (Collider2D other) {
        Player player = other.GetComponent<Player> ();
        if ( other != null ) {
            if ( other.tag == "Player" ) {
                player.LoseLife ();
                Debug.Log ("Num of lives now: " + player.NumOfLives);
                Die ();
            } else if ( other.tag == "Projectile" ) {
                Laser laser = other.GetComponent<Laser> ();
                if ( laser.laserID == 0 ) {
                    TakeDamage (damageTaken);
                    Destroy (other.gameObject);
                } else if ( laser.laserID == 1 ) {
                    TakeDamage (damageTaken * 2);
                    Destroy (other.gameObject);
                }
            }
        }

    }
    void Die () {
        
        Instantiate (explosionAnimation , transform.position , Quaternion.identity);
        _uiManager.UpdateScore ();
        Destroy (this.gameObject);
    }

}
