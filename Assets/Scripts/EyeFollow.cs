using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public GameObject GozBebegi;
    Camera camera;
    Vector3 vecMousePoz;

    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        vecMousePoz= camera.ScreenToWorldPoint(Input.mousePosition);
        
        vecMousePoz.z = 0;
        Debug.Log(vecMousePoz);
    }
}
