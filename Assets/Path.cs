using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Enemy tarEnt;
    public Vector3 toPoint;

    public bool isComplete;

    public Path(Enemy tarEntarg, Vector3 toPointarg)
    {
        tarEnt = tarEntarg;
        toPoint = toPointarg;
    }

    public void Stop()
    {
        isComplete = true;
    }

    public void Tick()
    {
        Vector3 diff = toPoint - tarEnt.position;
        tarEnt.heading = Mathf.Atan2(diff.x, diff.z) * (180 / Mathf.PI);
        tarEnt.heading = tarEnt.heading > 0 ? tarEnt.heading < 360 ? tarEnt.heading : tarEnt.heading - 360 : tarEnt.heading + 360;

        tarEnt.transform.localPosition = tarEnt.transform.localPosition + tarEnt.velocity * Time.deltaTime;


        tarEnt.velocity.x = Mathf.Sin(tarEnt.heading * Mathf.Deg2Rad) * tarEnt.speed;
        tarEnt.velocity.y = 0;
        tarEnt.velocity.z = Mathf.Cos(tarEnt.heading * Mathf.Deg2Rad) * tarEnt.speed;

        tarEnt.position = tarEnt.position + tarEnt.velocity * Time.deltaTime;
        tarEnt.transform.localPosition = tarEnt.position;

        tarEnt.eulerRotation.y = tarEnt.heading;
        tarEnt.transform.localEulerAngles = tarEnt.eulerRotation;

        if (Vector3.Distance(toPoint, tarEnt.transform.localPosition) < .35)
        {
            Stop();
        }
    }
}
