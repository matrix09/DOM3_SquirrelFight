using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActor : MonoBehaviour {

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

}
