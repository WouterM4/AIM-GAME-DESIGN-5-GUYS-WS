using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private KeyColors color;


    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = color.Color;
    }
}
