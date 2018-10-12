using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject _Laser;
    [SerializeField]
    public int NumOfLives = 3;
    public bool tripleFirePowerUp = false;
    [SerializeField]
    private GameObject tripleFirePowerUpLaser;
    public float speed = 5f;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _canFire = 0f;
    [SerializeField]
    private GameObject explosion;
    float h;
    float v;
    public bool shieldActive = false;
    [SerializeField]
    private GameObject Shields;
    [SerializeField]
    private AudioSource _audioSource;
    private UIManager uIManager;
    private void Start () {
        _audioSource = GetComponent<AudioSource> ();
        uIManager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
        if ( uIManager!= null ) {
            uIManager.UpdateLives (NumOfLives);
        }
    }


    void Update () {

        //Shield Status
        if ( shieldActive )
            Shields.SetActive (true);
        else
            Shields.SetActive (false);

        Movement ();
        Shoot ();
        if ( NumOfLives < 1 ) {
            Die ();
        }

    }



    void Movement () {
        h = Input.GetAxis ("Horizontal");
        v = Input.GetAxis ("Vertical");

        transform.Translate (Vector3.right * h * speed * Time.deltaTime);
        transform.Translate (Vector3.up * v * speed * Time.deltaTime);
        if ( transform.position.y > 0 )
            transform.position = new Vector3 (transform.position.x , 0 , 0);
        else if ( transform.position.y < -3.76f )
            transform.position = new Vector3 (transform.position.x , -3.76f , 0);
        //if x is greater than 9.26 set it to -8.42 and vice versa
        if ( transform.position.x > 9.26f )
            transform.position = new Vector3 (-9.26f , transform.position.y , 0);
        else if ( transform.position.x < -9.26f )
            transform.position = new Vector3 (9.26f , transform.position.y , 0);
    }
    void Shoot () {
        if ( Input.GetMouseButton (0) ) {
            if ( Time.time > _canFire ) {
                _audioSource.Play ();
                if ( tripleFirePowerUp ) {
                    _audioSource.pitch = 3;
                    Instantiate (tripleFirePowerUpLaser , transform.position , Quaternion.identity);
                } else if ( tripleFirePowerUp == false ) {
                    _audioSource.pitch = 1;
                    Instantiate (_Laser , transform.position + new Vector3 (-0.223f , 0f , 0f) , Quaternion.identity);
                }


                _canFire = Time.time + _fireRate;
            }

        }
    }
    void Die () {

        uIManager.ShowGameOverScreen ();
        Instantiate (explosion , transform.position , Quaternion.identity);
        Destroy (this.gameObject);

    }
    public void TripleShotPowerupOn () {
        tripleFirePowerUp = true;
        StartCoroutine (TripleShotPowerDown ());

    }
    private IEnumerator TripleShotPowerDown () {

        yield return new WaitForSeconds (5.0f);
        tripleFirePowerUp = false;

    }
    public void SpeedBoostOn () {
        speed = 20f;
        StartCoroutine (SpeedBoostDown ());

    }
    private IEnumerator SpeedBoostDown () {
        yield return new WaitForSeconds (10f);
        speed = 10f;
    }
    public int LoseLife () {
        if ( shieldActive ) {
            
            shieldActive = false;
            return 0;
        } else {
            NumOfLives--;
            uIManager.UpdateLives (NumOfLives);
            return 0;
        }

    }

}
