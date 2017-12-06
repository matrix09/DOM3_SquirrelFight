using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public Transform m_tMajor;

    public Vector3 offSet;

    public Vector3 dir;

    public float offSpeed;

    public float dirSpeed;

	// Update is called once per frame
	void Update () {

        Vector3 pos = m_tMajor.position + offSet;

        transform.position = Vector3.Lerp(transform.position, pos, offSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(dir), dirSpeed * Time.deltaTime);

	}
}
