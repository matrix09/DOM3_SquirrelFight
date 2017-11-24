using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour {


    public BallLauncher[] m_cBallLaunchers;


    public void OnStart()
    {
        for (int i = 0; i < m_cBallLaunchers.Length; i++)
        {
            m_cBallLaunchers[i].OnStart();
        }
    }

    public void OnEnd()
    {
        for (int i = 0; i < m_cBallLaunchers.Length; i++)
        {
            m_cBallLaunchers[i].OnEnd();
        }
    }

}
