using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation24h : MonoBehaviour
{
    public float speed = 60;//旋转速度60°每秒

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right * Time.deltaTime * speed);
	}
}
