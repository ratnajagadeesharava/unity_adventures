
using System;
using  UnityEngine;
public class Clock :MonoBehaviour
{
    [SerializeField]
    public Transform HoursPivot;
    [SerializeField]
    public Transform MinutesPivot;
    [SerializeField]
    public Transform SecondsPivot;

    private void UpdateAngleOnTime()
    {
        DateTime currentDateTime = DateTime.Now;
        float minuteAngle = (((currentDateTime.Minute)) * 6);
        MinutesPivot.localRotation = Quaternion.Euler(minuteAngle, 0, 0);
        float secondsAngle = (((currentDateTime.Second)) * 6);
        SecondsPivot.localRotation = Quaternion.Euler(secondsAngle, 0, 0);
        float angle = ((currentDateTime.Hour % 12)) * 360;
        angle = angle / 12;

        angle = angle + (minuteAngle * 0.5f);

        HoursPivot.localRotation = Quaternion.Euler(angle, 0, 0);
    }
    private void Awake()
    {
        UpdateAngleOnTime();
        

    }
    private void FixedUpdate()
    {
        print(HoursPivot.localRotation.x);
        UpdateAngleOnTime();
    }
}