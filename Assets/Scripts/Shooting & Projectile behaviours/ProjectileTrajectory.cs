using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory : MonoBehaviour
{
    [SerializeField] private float maxProjectileSpeed = 100f, initialSpeedDrop = 6f, speedDropSlow = 0.25f, rotationSpeed = 50;
    private float mySpeed, charge, speedDrop;
    private Rigidbody myRigidBody;
    private bool freezeObject = false;

	// Use this for initialization
	void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        speedDrop = initialSpeedDrop;
	}

    public void SetForce(float chargePercentage)
    {
        charge = chargePercentage;
        mySpeed = Mathf.Max(0, charge * maxProjectileSpeed);
    }

    void MoveObject()
    {
        myRigidBody.AddForce(transform.forward * mySpeed);
        myRigidBody.AddForce(Vector3.up * mySpeed);
    }

    void ApplyFalloff()
    {
        //Lower the amount of force that is being applied to the projectile so that it starts falling down due to gravity
        if (mySpeed > 0)
        {
            mySpeed -= speedDrop;
            mySpeed = Mathf.Max(mySpeed, 0);
        }

        //Gradually lower the speed lost over time
        if (speedDrop > 0)
        {
            speedDrop -= speedDropSlow;
            speedDrop = Mathf.Max(speedDrop, 0);
        }

        transform.Rotate(Time.deltaTime * rotationSpeed * Mathf.Clamp((1-charge), charge, 1), 0, 0);
    }

    public void StopProjectile()
    {
        myRigidBody.isKinematic = true;
        gameObject.GetComponent<Collider>().enabled = false;
        freezeObject = true;
    }
	
	void FixedUpdate ()
    {
        if (!freezeObject)
        {
            MoveObject();
            ApplyFalloff();
        }
	}
}