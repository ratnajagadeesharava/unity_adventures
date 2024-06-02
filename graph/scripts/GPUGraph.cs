using System;
using UnityEngine;

public class GPUGraph : MonoBehaviour
{
    [SerializeField, Range(10, 200)]
    int resolution = 10;
    //[SerializeField]
    //Transform pointPrefab;
    [SerializeField, Range(0, 0.3f)]
    float timeSpecifer;

    [SerializeField]
    ComputeShader computeShader;
    ComputeBuffer positionBuffer;

    [SerializeField]
    Material material;

    [SerializeField]
    Mesh mesh;


    static readonly int PositionId = Shader.PropertyToID("_Positions");
    static readonly int _StepId = Shader.PropertyToID("_Step");
    static readonly int _ResolutionId = Shader.PropertyToID("_ResolutionId");
    static readonly int _timeId = Shader.PropertyToID("_Time");

    private void Start()
    {
        
    }
    private void OnEnable()
    {
        positionBuffer = new ComputeBuffer(resolution * resolution, 3 * sizeof(float));
    }
    private void Update()
    {
        UpdateFunctionOnGPU();
    }
    void UpdateFunctionOnGPU()
    {
        float step = 2f/resolution;
        computeShader.SetFloat(_StepId, step);   
        computeShader.SetFloat(_timeId, Time.time);
        computeShader.SetInt(_ResolutionId, resolution);

        computeShader.SetBuffer(0,PositionId,positionBuffer);
        int groups = Mathf.CeilToInt(resolution / 8f); 
        computeShader.Dispatch(0, groups, groups, 1);
        material.SetBuffer(PositionId, positionBuffer);
        material.SetFloat(_StepId, step);
        var bounds  = new Bounds(Vector3.zero, Vector3.one);
        //Debug.Log
        Graphics.DrawMeshInstancedProcedural(mesh, 0, material,bounds,positionBuffer.count);

    }
    
    private void OnDisable()
    {
        positionBuffer.Release();
        positionBuffer = null;
    }
}