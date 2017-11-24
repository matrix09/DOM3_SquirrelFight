using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActor : MonoBehaviour {

    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }


    public static BallActor CreateBall(string path, Vector3 pos, Vector3 dir)
    {

        UnityEngine.Object _obj = Resources.Load(path);

        GameObject obj = Instantiate(_obj, pos, Quaternion.Euler (dir)) as GameObject;

        BallActor ba = obj.AddComponent<BallActor>();

        return ba;
    }

}
