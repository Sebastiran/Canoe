using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField] private float myDamage = 10f, destroyDelay = 2f, colActivationDelay = 0.1f, maxProjectileLife = 10f;
    private ProjectileTrajectory projectileMovement;

    void Start()
    {
        projectileMovement = GetComponent<ProjectileTrajectory>();
        StartCoroutine(EnableCollider());
        StartCoroutine(DestroyProjectile(maxProjectileLife));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != transform.root.tag)
        {
            if(col.gameObject.tag == "Surface")
            {
                Destroy(gameObject);
            }
            else if (col.gameObject.tag.Contains("Player"))
            {
                col.gameObject.GetComponent<PlayerHealth>().ApplyDamage(myDamage);
            }

            //transform.SetParent(col.transform, false);

            //Transform myParent = col.transform;
            //Vector3 originalScale = transform.localScale;
            //Vector3 parentScale = myParent.localScale;
            //Quaternion originalRotation = transform.rotation;

            //transform.parent = myParent;
            //transform.localScale = new Vector3(originalScale.x / parentScale.x, originalScale.y / parentScale.y, originalScale.z / parentScale.z);
            //transform.localRotation = originalRotation;

            projectileMovement.StopProjectile();
            StartCoroutine(DestroyProjectile(destroyDelay));
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(colActivationDelay);
        GetComponent<Collider>().enabled = true;
    }

    IEnumerator DestroyProjectile(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}