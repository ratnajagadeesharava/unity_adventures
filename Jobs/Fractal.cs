using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    struct FractalPart
    {
        public Transform transform;
        public Quaternion rotation;
        public Vector3 direction;
    }

    FractalPart[][] parts;
    //radius of sphere is 0.5 units
    [SerializeField]
    private int depth = 2;
    string test = "hello bum";
    [SerializeField]
    Mesh mesh;
    [SerializeField]
    Material material;
    static Vector3[] directions =
    {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.back,
        Vector3.forward,
    };
    static Quaternion[] rotations =
    {
        Quaternion.identity,
        Quaternion.Euler(0f,0f,-90f),
        Quaternion.Euler(0f,0f,90f),
        Quaternion.Euler(90f,0f,0f),
        Quaternion.Euler(-90f,0f,0f),
    };
    
    void Start()
    {
        Debug.Log(transform.position);
        if (depth <= 1)
        {
            return;
        }
        GenerateRecursiveFractal();
    }
    
    private void Awake()
    {
        //GenerateIteravtiveFractal();

    }

    private void GenerateIteravtiveFractal()
    {
        parts = new FractalPart[depth][];

        for (int i = 0, length = 1; i < depth; i++, length *= 5)
        {
            parts[i] = new FractalPart[length];
            Debug.Log(length);
        }

        for (int li = 0; li < depth; li++)
        {
            FractalPart[] levelParts = parts[li];
            for (int fpi = 0; fpi < levelParts.Length; fpi++)
            {
                levelParts[fpi] = CreatePart(fpi, li);
            }
        }
        for (int li = 1; li < depth; li++)
        {
            FractalPart[] levelParts = parts[li];
            for (int fpi = 0; fpi < levelParts.Length; fpi++)
            {
                levelParts[fpi].transform.SetParent(parts[li - 1][fpi / 5].transform, false);
            }
        }
    }
    private FractalPart CreatePart(int fpi,int li)
    {
        //float scale = Mathf.Pow(0.5f, li);
        GameObject go = CreateComponent(li, fpi,0.5f);
        go.transform.localPosition = 0.75f*directions[fpi % 5];
        return new FractalPart() {
            direction = directions[fpi % 5],
            rotation = rotations[fpi % 5],
            transform = go.transform,
            };
    }
    GameObject CreateComponent(int levelIndex,int childIndex,float scale)
    {
        GameObject gameObject = new GameObject("Fractal Object--"+levelIndex+"C__"+childIndex);
        gameObject.transform.localScale = scale*Vector3.one;
        gameObject.transform.SetParent(transform, false);
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        return gameObject;
    }

    void GenerateRecursiveFractal()
    {
        Fractal childA = generateChildFractal(0.75f * Vector3.right);
        Fractal childB = generateChildFractal(0.75f * Vector3.up);
        Fractal childC = generateChildFractal(0.75f * Vector3.left);
        Fractal childD = generateChildFractal(0.75f * Vector3.forward);
        Fractal childE = generateChildFractal(0.75f * Vector3.back);
        childA.transform.SetParent(transform, false);
        childB.transform.SetParent(transform, false);
        childC.transform.SetParent(transform, false);
        childD.transform.SetParent(transform, false);
        childE.transform.SetParent(transform, false);
    }
    Fractal generateChildFractal(Vector3 direction)
    {
        if(depth == 2)
        {
            this.test = "changed string";
        }
        Fractal fractal = Instantiate(this);
        fractal.depth = depth - 1;
        fractal.name = "F__" + depth;
        //Debug.Log("Generated Child: " + fractal.name + " at Depth: " + fractal.depth);
        fractal.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        fractal.transform.localPosition = direction;
        return fractal;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 22.5f * Time.deltaTime;
        transform.Rotate(0f, angle, 0);
    }
}
