using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed;

    public Enemy toEnt;

    public Vector3 position, velocity;

    public float heading;

    public Projectile inst;

    public Projectile(Vector3 from, Enemy to)
    {
        position = from;
        toEnt = to;
        velocity = new Vector3(0, 0, 0);
        heading = 0;
        speed = 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, 0);
        heading = 0;
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateMgr.inst.isGamePaused)
        {
            Vector3 rel = toEnt.velocity - velocity;
            float dist = Vector3.Distance(toEnt.position, position);
            float t = dist / rel.magnitude;
            Vector3 diff = (toEnt.position + toEnt.velocity * t) - position;
            heading = Mathf.Atan2(diff.x, diff.z) * (180 / Mathf.PI);
            heading = heading > 0 ? heading < 360 ? heading : heading - 360 : heading + 360;

            velocity.x = Mathf.Sin(heading * Mathf.Deg2Rad) * speed;
            velocity.y = 0;
            velocity.z = Mathf.Cos(heading * Mathf.Deg2Rad) * speed;

            position = position + velocity * Time.deltaTime;
            transform.localPosition = position;

            if (dist < 0.75f)
                Stop();
        }
    }

    public void Stop()
    {
        if (toEnt.unitLife > 0)
        {
            toEnt.decrementLives();
        }
        Destroy(this.gameObject);
    }
}
