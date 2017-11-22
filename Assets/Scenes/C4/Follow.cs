using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public float fmoveSpeed;

    public Vector3 OffSet;

    public Vector3 Dir;

    public Transform player;
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = player.position + OffSet;

        Vector3 dir = Dir;

        transform.position = Vector3.Lerp(transform.position, pos, 10 * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(dir), 10 * Time.deltaTime);

	}
}
