using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    // Use this for initialization
    void Start () {


        // pozyskanie obiektu GameController
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");//wypisanie loga, jeśli się nie uda znalesc GameController'a
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}


    //usuwa obiekty z którymi ma kontakt
    void OnTriggerEnter(Collider other)
    {
        //jesli obiektem jest Boundary, to nie usuwaj tego obiektu
        if (other.tag == "Boundary")
        {
            return;
        }

        //eksplozja  przeciwników
        Instantiate(explosion, transform.position, transform.rotation);

        //eksplozja gracza
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            
        }
        gameController.AddScore(scoreValue);// dodawanie wyniku po zniszczeniu przeciwnika

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
