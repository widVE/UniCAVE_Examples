using UnityEngine;
using System.Collections;

public class Random_movement : MonoBehaviour {
	Vector3 dir;
	// Use this for initialization
	void Start () {
	
			dir = Quaternion.Euler(0f,Random.Range(0,360f),0f)*Vector3.forward;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.Translate(dir/20f);
	}
}
