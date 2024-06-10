using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphGPU : MonoBehaviour
{
    [SerializeField]
    ComputeShader computeShader;
    [SerializeField, Range(10, 200)]
    int Resolution;
    ComputeBuffer computeBuffer;


    
    private void OnEnable()
    {
        computeBuffer = new ComputeBuffer(Resolution * Resolution, 3 * sizeof(float));
    }

    private void UpdateOnGPU()
    {

    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        computeBuffer.Release();
        computeBuffer = null;
    }

}
