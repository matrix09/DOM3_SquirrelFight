using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.WE_1 {
    public class GameController : MonoBehaviour {

        public LauncherController m_cLauncherCtrl;

        bool m_bStart = false;

        string[] BtnNames = new string[] { "Begin Game", "End Game"};

        string BtnName;

        void OnGUI()
        {
            if (!m_bStart)
            {
                BtnName = BtnNames[0];
            }
            else {
                BtnName = BtnNames[1];
            }

            if (GUI.Button(new Rect(0f, 0f, 100f, 100f), BtnName))
            {
                m_bStart = !m_bStart;
                if (m_bStart)
                    m_cLauncherCtrl.OnStart();
                else
                    m_cLauncherCtrl.OnEnd();
            }
      
        }

    }
}

