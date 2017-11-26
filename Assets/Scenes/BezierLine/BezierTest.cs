using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTest : MonoBehaviour {

    public Transform m_tMajor;

    public BezierCurve m_cCurve;

    float t = 0f;
    Transform Major;
	// Use this for initialization
	void Start () {
        Major = Instantiate<Transform>(m_tMajor);
        Major.position = m_cCurve.GetPoint4(0);
        Major.rotation = Quaternion.Euler(m_cCurve.GetDirection4(0f));
	}
	
	// Update is called once per frame
	void Update () {

        if (t >= 1f)
            t = 0f;

        Vector3 pos = m_cCurve.GetPoint4(t);
        Major.position = Vector3.Lerp(Major.position, pos, 10f * Time.deltaTime);

        Vector3 dir = m_cCurve.GetDirection4(t);
        Major.rotation = Quaternion.Lerp(Major.rotation, Quaternion.Euler(dir), 10 * Time.deltaTime);


        t +=  0.1f * Time.deltaTime;


	}
}
