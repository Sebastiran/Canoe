using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Bomb : Power
{
    float speed = 30;
    float blastRadius = 10f;

    public override void UsePower(GameObject caster)
    {
        power = new Throw();
        transform.position = power.GetOrigin(caster);
        Vector3 direction = power.GetDirection(caster.transform.forward);
        GetComponent<Rigidbody>().velocity = direction * speed;
        base.UsePower(caster);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Bom Hit!");
        if (blastRadius > 0f)
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, blastRadius, Vector3.up, 0.1f);
            foreach (RaycastHit hit in hits)
            {
                if(hit.transform.gameObject.tag == "Player")
                {
                    //hit.transform.gameObject.GetComponent<Creature>().RecieveDamage(damage);
                }
            }
        }
        else
        {
            //col.gameObject.GetComponent<Creature>().RecieveDamage(damage);
        }
        Destroy(gameObject);
    }
}
