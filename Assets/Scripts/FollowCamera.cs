
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    public Transform rain;
    public float height;
    //位置偏移
    private Vector3 offsetPosition;

    void Start()
    {
        offsetPosition.x = rain.position.x - Player.position.x;//得到偏移量
        offsetPosition.z = rain.position.z - Player.position.z;//得到偏移量
        offsetPosition.y = Player.position.y + height;//高度偏移
    }
 
    void Update()
    {
        rain.position = offsetPosition + Player.position;
 
    }
}