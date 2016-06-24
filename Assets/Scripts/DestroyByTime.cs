using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    //Skrypt usuwa obiekt gry po upłynięciu danego czasu

    //Wykorzystywany do usuwania obiektów eksplozji
    public float lifetime;


    // Use this for initialization

    void Start()
    {
        Destroy(gameObject, lifetime);
    }


}
