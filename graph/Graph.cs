using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Graph : MonoBehaviour
{

    [SerializeField]
    Transform pointPrefab;
    [SerializeField, Range(10, 40)]
    int noOfObjects = 20;
    [SerializeField, Range(0,1)]
    float timeSpecifier = 1.0f;
    List<Transform> points = new List<Transform>();
    float t = 0;
    private void Awake()
    {
        
        int i = -noOfObjects;
        this.gameObject.transform.localScale = Vector3.one / 5;
        while (i <= noOfObjects)
        {

            Transform point = Instantiate(pointPrefab);
            points.Add(point);
            point.transform.localScale = Vector3.one / 5;
            point.transform.localPosition = new Vector3((float)(0.5 * i), 1.2f*Mathf.Sin((float)(i * 0.25)), 0);

            i++;

        }
    }
    private void Update()
    {
        int i = 0;
        foreach (Transform point in points)
        {
            point.transform.localPosition = new Vector3((float)(0.5 * i), 1.2f * Mathf.Sin((float)(i * 0.25) +t), 0);
            i++;
        }
        t = t +timeSpecifier;
    }
}