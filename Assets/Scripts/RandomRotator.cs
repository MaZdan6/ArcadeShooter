using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {



    public float tumble;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();

        //nadawanie losowej rotacji
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
