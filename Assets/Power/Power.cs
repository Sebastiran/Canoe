using UnityEngine;
using System.Collections;
using System;

public class Power : MonoBehaviour
{
    public PowerType power;

    public virtual void UsePower(GameObject caster)
    {
        
    }

    public void SetPowerType(PowerType type)
    {
        power = type;
    }
}

public class Throw : PowerType
{
    public Vector3 GetDirection(Vector3 forward)
    {
        Vector3 direction = (forward * 2) + Vector3.up;
        return direction.normalized;
    }

    public Vector3 GetOrigin(GameObject caster)
    {
        Vector3 origin = caster.transform.position;
        origin += new Vector3(0, 2, 0);
        return origin;
    }
}

public interface PowerType
{
    Vector3 GetDirection(Vector3 forward);
    Vector3 GetOrigin(GameObject caster);
}