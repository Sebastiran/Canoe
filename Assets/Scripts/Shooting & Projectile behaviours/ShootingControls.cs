﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private float maxCharge = 3f, shotCooldown = 1.5f, minimumForce = .10f;
    [SerializeField] Quaternion firingAngle;
    [SerializeField] private KeyCode weaponSwitchKey;
    private GameObject currentProjectile, newProjectile;
    private float currentCharge = 0, currentCooldown = 0;
    private int nextProjectileIndex;
    private bool shotCharging = false;

	// Use this for initialization
	void Start ()
    {
        currentProjectile = projectiles[0];
        firingAngle = transform.rotation;
	}

    void ChangeProjectile()
    {
        //Check what weapon is currently used and where it resides in the list
        nextProjectileIndex = projectiles.IndexOf(currentProjectile) + 1;

        //Switch back to the first weapon if the end of the list has been reached
        if (nextProjectileIndex > projectiles.Count - 1)
        {
            nextProjectileIndex = 0;
        }

        //Switch to the next weapon
        currentProjectile = projectiles[nextProjectileIndex];
    }

    void ReleaseShot(float force)
    {
        newProjectile = Instantiate(currentProjectile, transform.position, firingAngle, transform) as GameObject;
        newProjectile.GetComponent<ProjectileTrajectory>().SetForce(force);
    }

    // Update is called once per frame
    void Update ()
    {
        //Hold to charge up the shot's power (distance/damage dealt)
        if (Input.GetMouseButton(0))
        {
            if (currentCharge >= maxCharge)
            {
                currentCharge = maxCharge;
            }
            else
            {
                currentCharge += Time.deltaTime;
            }
        }

        //Fire a projectile
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseShot(Mathf.Max(minimumForce, (currentCharge / maxCharge)));
            currentCharge = 0;
        }

        //Switch between weapons
        if (Input.GetKeyDown(weaponSwitchKey))
        {
            ChangeProjectile();
        }

        currentCooldown += Time.deltaTime;
	}
}