using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingControls : MonoBehaviour
{
	[SerializeField] Slider shootingCharge;
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private float maxCharge = 3f, shotCooldown = 1.5f, minimumPercentage = .67f;
    [SerializeField] private KeyCode weaponSwitchKey;
    private GameObject currentProjectile, newProjectile;
    private float currentCharge = 0, currentCooldown = 0;
    private int nextProjectileIndex;
    private bool shotAllowed = true;

	// Use this for initialization
	void Start ()
    {
        Mathf.Clamp01(minimumPercentage);
        currentProjectile = projectiles[0];
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
<<<<<<< HEAD
		newProjectile = Instantiate(currentProjectile, transform.position, firingAngle) as GameObject;
=======
        newProjectile = Instantiate(currentProjectile, transform.position, transform.rotation);
>>>>>>> b881e84b4a48deb51b616b43c3ab27a76c095d75
        newProjectile.GetComponent<ProjectileTrajectory>().SetForce(force);
        newProjectile.tag = transform.root.tag;
    }

    // Update is called once per frame
    void Update ()
    {
        if (currentCooldown < shotCooldown)
        {
            currentCooldown += Time.deltaTime;
        }
        else if (currentCooldown > shotCooldown)
        {
            currentCooldown = shotCooldown;
            currentCharge = maxCharge * minimumPercentage;
            shotAllowed = true;
        }

        if (shotAllowed)
        {
            //Hold to charge up the shot's power (distance)
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
                ReleaseShot(currentCharge / maxCharge);
                currentCharge = 0;
                currentCooldown = 0;
                shotAllowed = false;
            }

			shootingCharge.value = (currentCharge / maxCharge);
        }

        //Switch between weapons
        if (Input.GetKeyDown(weaponSwitchKey))
        {
            ChangeProjectile();
        }
	}
}