using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMeshBounds : MonoBehaviour
{
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void Update()
    {
        Debug.Log($"_bounds : {_meshFilter.mesh.bounds.ToString("F3")}");
    }
}
