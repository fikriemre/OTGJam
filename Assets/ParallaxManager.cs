using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{

    public static ParallaxManager Instance;
    
    public float speed;

    public GameObject[] parallaxes;

    private float horizontalValue;

    private List<Material> _materials = new List<Material>();
    
    private Vector2 offset;

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < parallaxes.Length; i++)
        {
            _materials.Add(parallaxes[i].GetComponent<MeshRenderer>().material);
        }
    }

    private void Update()
    {
        for (int i = 0; i < parallaxes.Length; i++)
        {
            _materials[i].mainTextureOffset =
                new Vector2(transform.position.x * speed * (1 - ((float) i / parallaxes.Length)), 0);
            
        }

    }
}
