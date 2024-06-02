using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Graph : MonoBehaviour
{

    [SerializeField]
    Transform pointPrefab;
    //[SerializeField, Range(10, 400)]
    //int noOfObjects = 100;

    [SerializeField, Range(0, 200)]
    int noOfLevels = 20;
    [SerializeField, Range(0,0.3f)]
    float timeSpecifier = 1.0f;
    List<Transform> points = new List<Transform>();
    float t = 0;
    private void UpdatePlane()
    {
        int i = 0;
        foreach (Transform point in points)
        {
            float x = point.localPosition.x;
            float y = point.localPosition.y;
            float z = point.localPosition.z;
            //point.transform.localPosition = new Vector3(x, y, FunctionLibrary.Ripple(x, y, t));
            i++;
        }
        t = t + timeSpecifier;
    }
    private void GeneratePlane()
    {
        int count = 0;
        for (int i = 0; i < noOfLevels; i++)
        {
            for (int j = 0; j < noOfLevels - i; j++)
            {
                Transform point = Instantiate(pointPrefab);
                point.localPosition = new Vector3(j, i, 0);
                points.Add(point);
                count++;
                if (i != 0)
                {
                    
                    Transform point3 = Instantiate(pointPrefab);
                    point3.localPosition = new Vector3(j, -i, 0);
                    points.Add(point3);
                    count++;
                }
                if (j != 0)
                {
                    Transform point2 = Instantiate(pointPrefab);
                    point2.localPosition = new Vector3(-j, i, 0);
                    points.Add(point2);
                    Transform point4 = Instantiate(pointPrefab);
                    point4.localPosition = new Vector3(-j, -i, 0);
                    points.Add(point4);
                    count++;
                    count++;
                }


            }
        }
        Debug.Log(count);    
    }
    private void Awake()
    {
        
        
        this.gameObject.transform.localScale = Vector3.one / 205;
        GeneratePlane();
        //int r = 10;
        ////FunctionLibrary.GenerateSphere(0, 0, 0, 10);
        //int noOfObjects = 30;
        //float angle = 0;
        //for(int i = 0; i < noOfObjects; i++)
        //{
        //    Transform point = Instantiate(pointPrefab);
        //    point.localPosition = FunctionLibrary.GenerateCircle(new Vector3(0,0,0), 10, angle);
        //    angle += 360 / angle;

        //}
    }
    private void Update()
    {
        UpdatePlane();
    }
}