using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {


    //niszczy każdy obiekt, który przestanie dotykać obiekt Cube
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
