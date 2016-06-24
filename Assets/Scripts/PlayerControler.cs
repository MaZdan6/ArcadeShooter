using UnityEngine;
using System.Collections;


[System.Serializable]//serializowanie klasy. Dzięki temu parametru będą widoczne w GUI Unity
public class Boundary//klasa posiadająca granice widoku
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour {



	public float speed;//predkosc poruszania sie gracza
	public float tilt;//wielkosc przechylenia
	public Boundary boundary;
	private Rigidbody rigidbody;//model gracza

    //strzelanie
    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;


    //pobranie modelu na poczatku dzialania skryptu
    void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

    //metoda jest wywoływana przed wykonaniem każdej klatki
    void Update()
    {

        //strzelanie
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            //po naciśnięciu strzału, tworzona jest instancja strzału
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
	void FixedUpdate ()
	{
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed;//ustawianie predkosci poruszania sie


		//ograniczenie poruszania sie gracza w granicach mapy

		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				0.0f,//ograniczenie możliwości poruszania sie w osi Y
				Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

		//przechylenie modelu
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);

	}
}
