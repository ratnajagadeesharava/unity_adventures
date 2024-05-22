using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicalCube : MonoBehaviour
{

    private void Awake()
    {
        print("hello Cube");
        int i = -1;
        gameObject.transform.localScale = Vector3.one / 5;
        while (i <= 1)
        {
            //Transform prefab = game
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
