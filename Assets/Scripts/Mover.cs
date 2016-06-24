using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rigidbody;//model gracza
    public float speed;
    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
