using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class CustomFaceCreator : MonoBehaviour
{
    [SerializeField] private ARFaceManager _faceManager;
    [SerializeField] private ARFace _defaultFacePrefab;
    [SerializeField] private RawImage _image;
    [SerializeField] private Camera _arCamera;
    
    private Mesh _mesh;
    private Bounds _bounds;
    private ARFace _activeFace;

    private void Awake() => _mesh = new Mesh();
    private void OnEnable() => _faceManager.facesChanged += FaceDataChanged;
    private void OnDisable() => _faceManager.facesChanged -= FaceDataChanged;
    
    private void FaceDataChanged(ARFacesChangedEventArgs args)
    {
        foreach (var face in args.added)
        {
            face.updated += FaceUpdate;
            Debug.Log($"add face {face.name}");
            
            foreach (var vertice in face.vertices)
                Debug.Log($"vertice {vertice}");

            foreach (var indice in face.indices)
                Debug.Log($"indice {indice}");
            
            foreach (var uv in face.uvs)
                Debug.Log($"indice {uv}");
            
            // gameObject.SetActive(false);
        }
        
        foreach (var face in args.removed)
        {
            Debug.Log($"remove face {face.name}");
        }
        
        // foreach (var face in args.updated)
        // {
        //     Debug.Log($"updated face {face.name}");
        // }
    }

    private void FaceUpdate(ARFaceUpdatedEventArgs args)
    {
        _mesh.vertices = args.face.vertices.ToArray();
        _mesh.triangles = args.face.indices.ToArray();
        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();

        _bounds = _mesh.bounds;
        Debug.Log($"_bounds = {_bounds.ToString("F3")}");
    }

    private void FillImage()
    {
        // _image.texture =    
    }
}
