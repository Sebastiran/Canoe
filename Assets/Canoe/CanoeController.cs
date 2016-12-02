using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CanoeController : MonoBehaviour
{
    Rigidbody mRigidbody;
    Animator mAnimator;
    Vector3 moveDirection;
    float peddleForce = 1000;
    [SerializeField] string player;
    [SerializeField] float maxSpeed = 50f;
    bool underwater = false;

    GameObject power = null;
    public GameObject[] powers;

    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();
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

        if (Input.GetAxis("UsePower_" + player) > 0)
        {
            if(power)
            {
                GameObject p = Instantiate(power);
                p.GetComponent<Power>().UsePower(gameObject);
                power = null;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Power")
        {
            if(!power)
            {
                power = powers[Random.Range(0, powers.Length)];
            }
            col.transform.parent.gameObject.GetComponent<PowerBox>().Used();
        }
    }

    /*Invoke("Dive", 1f);
            underwater = !underwater;
            mRigidbody.useGravity = !underwater;*/

    /*transform.parent.position = new Vector3(transform.position.x, 0, transform.position.z);
    transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
    mAnimator.SetTrigger("Dive");
    mAnimator.SetBool("Underwater", !mAnimator.GetBool("Underwater"));*/

    /*void Dive()
    {
        if (underwater)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y - 5, 1f));
        }
        else
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + 5, 1f));
        }
    }*/

    /*IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        //mRigidbody.useGravity = !underwater;
    }*/
}
