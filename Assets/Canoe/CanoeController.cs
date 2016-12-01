using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CanoeController : MonoBehaviour
{
    
    Rigidbody mRigidbody;
    Vector3 moveDirection;
    float peddleForce = 1000;
    [SerializeField] string player;
    [SerializeField] float maxSpeed = 50f;

    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        moveDirection = Vector3.zero;
    }

    void Update()
    {
        float gas = Input.GetAxis("Vertical_" + player);
        float steer = Input.GetAxis("Horizontal_" + player);
        mRigidbody.AddForce(transform.forward * gas * peddleForce * Time.deltaTime);
        transform.Rotate(0, steer, 0);
        if (mRigidbody.velocity.magnitude > maxSpeed)
            mRigidbody.velocity = mRigidbody.velocity.normalized * maxSpeed;
    }
}
