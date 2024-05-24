
using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary
{
    public static float Wave(float x,float y,float t)
    {
        float theta = 0.2f*PI * (y + t) ;
        float a = 0.06f*PI;
        float b = 5;
        float z = b*Sin(a*(y+t));
       
        return z;
    }

    public static Vector3 DoublePyramid(float x, float y, float z)
    {
        return new Vector3(x,y,z);
    }

    public static float Ripple(float x,float y,float t)
    {
        float d = 0.2f*PI*Sqrt(Abs(y*y+x*x+t));
        float z = 40f*Cos(d+t);
        //z += 10f*Sin(d);
        
        //Debug.Log(t);
        if(d!=0) 
        return z/d;
        else 
            return z;
    }

    public static float MultiWave(float x,float t)
    {
        //t = 0;
        float y = Sin((x + t));
        y += Sin(2f  * (x + t))/2f+Cos(x+t);
        return y;
    }
}