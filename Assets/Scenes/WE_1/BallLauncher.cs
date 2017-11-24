using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {

    public float m_fFrequence;// 球体生成的频率
    public GameObject m_oBallActor;//球体实例对象脚本

    bool m_bFireBall;
    float m_fStartTime;
    public void OnStart()
    {
        m_bFireBall = true;
        m_fStartTime = Time.time;
        FireBall();
    }

    public void OnEnd()
    {
        m_bFireBall = false;
    }

    void Update()
    {
        if (!m_bFireBall)
            return;

        //发射球体
        if (Time.time - m_fStartTime > m_fFrequence)
        {
            m_fStartTime = Time.time;
            FireBall();
        }

    }

    void FireBall()
    {
        Instantiate(m_oBallActor, transform.position, Quaternion.identity);
    }

}
