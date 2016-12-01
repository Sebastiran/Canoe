using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrajectory : MonoBehaviour
{
    [SerializeField] private float maxProjectileSpeed = 100f, percentageOfMaxSpeed = 0.67f, initialSpeedDrop = 6f, speedDropSlow = 0.25f;
    private float mySpeed, minProjectileSpeed, newRotation, speedDrop;
    private Rigidbody myRigidBody;

	// Use this for initialization
	void Awake()
    {
        myRigidBody = GetComponent<Rigidbody>();
        newRotation = transform.rotation.x;
        minProjectileSpeed = maxProjectileSpeed * percentageOfMaxSpeed;
        speedDrop = initialSpeedDrop;
	}

    public void SetForce(float chargePercentage)
    {
        mySpeed = Mathf.Max(minProjectileSpeed, chargePercentage * maxProjectileSpeed);
    }

    void ApplyFalloff()
    {
        if (mySpeed > 0)
        {
            mySpeed -= speedDrop;
            mySpeed = Mathf.Max(mySpeed, 0);
        }

        if (speedDrop > 0)
        {
            speedDrop -= speedDropSlow;
            speedDrop = Mathf.Max(speedDrop, 0);
        }

        newRotation -= speedDrop;

        transform.rotation = new Quaternion(newRotation, transform.rotation.y, transform.rotation.z, transform.rotation.w);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        myRigidBody.AddForce(Vector3.forward * mySpeed);
        myRigidBody.AddForce(Vector3.up * mySpeed);

        ApplyFalloff();
        //myPosition += Vector3.forward * Mathf.Clamp(mySpeed, 0, maxProjectileSpeed);
        //transform.position = new Vector3(myPosition.x, myPosition.y, myPosition.z);
	}
}
