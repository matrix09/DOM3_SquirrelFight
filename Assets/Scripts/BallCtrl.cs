using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour {

    Rigidbody rb;
    public float m_fDelayTime;
    bool m_bTrigger = false;
    float m_fStartTime;
    public void OnStart(float delayTime)
    {
        m_bTrigger = true;
        m_fDelayTime = delayTime;
        m_fStartTime = Time.time;
    }

    void Update()
    {
        if(!m_bTrigger) return;

        if (Time.time - m_fStartTime > m_fDelayTime)
        {
            m_bTrigger = false;
            gameObject.AddComponent<Rigidbody>();
        }

    }

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

}
