using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Stellar;
public class PlayerManager : MonoBehaviour
{

    #region 变量
    public Stellar m_cStellar;  //获取曲线信息
    float he = 0f;
    float m_fT = 0f;
    Vector3 pos;
    Animator am;
    const float headPer = 0.01f;
    Vector3 headPos;
    #endregion

    #region 角色移动
    void CharacterMove()
    {
        he = Input.GetAxis("Horizontal");
        if (he == 0f)
        {
            am.SetFloat("Speed", 0f);
            return;
        }

        if (m_fT >= 1f && he >= 0f)
        {
            m_cStellar.LinkPoints(out m_fT);
        }
         

        if (m_fT < 0f)
            m_fT = 0f;

        if (m_fT >= headPer && m_fT <= 1f)
        {
            if (he > 0f)
            {
                headPos = m_cStellar.Interp(m_fT + headPer);
            }
            else
            {
                headPos = m_cStellar.Interp(m_fT - headPer);
            }

            transform.LookAt(headPos);

        }

        pos = m_cStellar.Interp(m_fT);
        transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, transform.position.y, pos.z), 5 * Time.deltaTime);

        m_fT += m_cStellar.GetDeltaT(m_fT) * Time.deltaTime * (he > 0f ? 1 : -1);
        am.SetFloat("Speed", 1f);
    }
    #endregion

    #region 系统接口
    void Start()
    {
        am = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        CharacterMove();    //角色运动
    }
    #endregion
}
