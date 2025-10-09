using System;
using UnityEngine;

public class ColoredObject : MonoBehaviour
{
    [SerializeField] private Color _color;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = _color;
    }
}
