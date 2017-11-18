using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    bool m_bIsTriggerBall = true;
    void LoadBalls()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = Instantiate(Resources.Load("CAT")) as GameObject;
            BallCtrl bc = obj.GetComponent<BallCtrl>();
            bc.OnStart(i);
        }
    }
    
    void OnGUI()
    {
         /*
          * 0 uniyt工程启动流程
          * 0.1 ： 什么是class
          * 0.2 class的基本构成
         * 1 接口的构成.
         * 2 if的使用方法.
           3 bool 变量的使用
          * 4接口的调用
          * 5循环遍历
          * 6动态加载预制体 
          * 7脚本启动
          * 8刚体碰撞器和刚体碰撞矩阵
          * 9 transform, gameObject
          * 10内存的理解.
         * */
        if (GUI.Button(new Rect(Screen.width - 100f, 0f, 100f, 100f), "Load Sphere"))
        {
            if (m_bIsTriggerBall)
            {
                LoadBalls();
                m_bIsTriggerBall = false;
            }
           
        }
    }

}
