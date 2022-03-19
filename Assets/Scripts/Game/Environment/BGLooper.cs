using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BGLooper : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Material _material;
    private Vector2 _offset;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
        _offset = _material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        _offset.x += _speed * Time.deltaTime;
        _material.SetTextureOffset("_MainTex", _offset);
    }
}
