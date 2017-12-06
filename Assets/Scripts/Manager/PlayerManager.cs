using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Stellar;
public class PlayerManager : MonoBehaviour {

    public Stellar m_cStellar;  //获取曲线信息

    float he = 0f;

    float m_fT = 0f;
    Vector3 pos;

    Animator am;

    void Start()
    {
        am = gameObject.GetComponent<Animator>();
    }

	void Update () {

        CharacterMove();    //角色运动

	}

    void CharacterMove()
    {
        he = Input.GetAxis("Horizontal");
        if (he == 0f)
        {
            am.SetFloat("Speed", 0f);
            return;
        }
         

        if (m_fT >= 1f)
            m_fT = 0f;

        pos = m_cStellar.Interp(m_fT);

        transform.forward = m_cStellar.GetDir(m_fT);

        transform.position = Vector3.Lerp(transform.position, new Vector3(pos.x, transform.position.y, pos.z), 5 * Time.deltaTime);

        m_fT += m_cStellar.GetDeltaT(m_fT) * Time.deltaTime * (he > 0f ? 1 : -1);


        am.SetFloat("Speed", 1f);


    }

}
