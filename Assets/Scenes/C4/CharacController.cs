using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacController : MonoBehaviour {


    public float m_fMoveSpeed;

    public float m_fRotSpeed;

	// Use this for initialization
	void Start () {
		
	}

    float he, ve;
	// Update is called once per frame
	void Update () {

        he = Input.GetAxis("Horizontal");
        ve = Input.GetAxis("Vertical");

        Quaternion dir = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);

        Vector3 right = dir * Vector3.right;

        Vector3 forward = dir * Vector3.forward;

       // Vector3 right = Vector3.right;

        //Vector3 forward = Vector3.forward;


        Vector3 move = he * right + ve * forward;

        if (Vector3.zero != move)
        {
            transform.forward = move;// Vector3.Lerp(transform.forward, move, m_fRotSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * m_fMoveSpeed  * Time.deltaTime, Space.Self);
        }

	}
}
