using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacController : MonoBehaviour {

    public float m_fMoveSpeed;

    public float m_fRotSpeed;

    float he, ve;
    Vector3 right, move;
    Quaternion dir;
    Vector3 forward;
	void Update () {
        //int n = Random.Range(0, 9);
        //if (n != 3 && n != 8 && n != 0)
        //{
        //    Debug.Log(n);
        //}
        he = Input.GetAxis("Horizontal");
        ve = Input.GetAxis("Vertical");

        dir = Quaternion.Euler(0f, Camera.main.transform.rotation.eulerAngles.y, 0f);

         right = dir * Vector3.right;

         forward = dir * Vector3.forward;

        //Vector3 right = Vector3.right;

        //Vector3 forward = Vector3.forward;


        move = he * right + ve * forward;

        if (Vector3.zero != move)
        {
            transform.forward = move;// Vector3.Lerp(transform.forward, move, m_fRotSpeed * Time.deltaTime);
            //transform.Translate(Vector3.forward * m_fMoveSpeed  * Time.deltaTime, Space.Self);
            transform.Translate(transform.forward * m_fMoveSpeed * Time.deltaTime, Space.World);
        }

	}
}
