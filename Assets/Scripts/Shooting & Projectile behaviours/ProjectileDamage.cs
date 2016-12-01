using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private float myDamage = 10f, destroyDelay = 2f, colActivationDelay = 0.1f;
    private ProjectileTrajectory projectileMovement;

    void Start()
    {
        projectileMovement = GetComponent<ProjectileTrajectory>();
        StartCoroutine(EnableCollider());
    }

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject != transform.root)
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<PlayerHealth>().ApplyDamage(myDamage);
            }

            transform.SetParent(col.transform);

            projectileMovement.StopProjectile();
            StartCoroutine(DestroyProjectile());
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(colActivationDelay);
        GetComponent<Collider>().enabled = true;
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}