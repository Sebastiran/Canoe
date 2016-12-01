using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CanoeController : MonoBehaviour
{
    Rigidbody mRigidbody;
    Vector3 moveDirection;
    float peddleForce = 1000;
    [SerializeField] float maxSpeed = 50f;

    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
    }

    void Update()
    {
        float gas = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        mRigidbody.AddForce(transform.forward * gas * peddleForce * Time.deltaTime);
        transform.Rotate(0, steer, 0);
        if (mRigidbody.velocity.magnitude > maxSpeed)
            mRigidbody.velocity = mRigidbody.velocity.normalized * maxSpeed;
    }
}
