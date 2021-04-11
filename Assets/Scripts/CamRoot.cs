using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRoot : MonoBehaviour
{
    public static Camera cam;
    public static CamRoot instance;

    private void Awake()
    {
        cam = Camera.main;
    }

    
    private Vector3 OldPos=Vector3.zero;
    private void Update()
    {

    Vector3 MoveDir = Vector3.zero;
    MoveDir.x = Input.GetAxis("Horizontal");
    MoveDir.y = Input.GetAxis("Vertical");
        
        if (Player.Instance)
        {
            transform.position =
                Vector3.Lerp(transform.position, Player.Instance.transform.position+MoveDir*5, Time.deltaTime * 5);
        }
    }
}