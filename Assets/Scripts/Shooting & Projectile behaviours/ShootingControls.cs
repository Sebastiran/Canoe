using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingControls : MonoBehaviour
{
	[SerializeField] private KeyCode p1Fire, p2Fire;
	[SerializeField] Slider shootingCharge;
    [SerializeField] private List<GameObject> projectiles;
    [SerializeField] private float maxCharge = 3f, shotCooldown = 1.5f, minimumPercentage = .67f;
    [SerializeField] private KeyCode weaponSwitchKey;
    private GameObject currentProjectile, newProjectile;
    private float currentCharge = 0, currentCooldown = 0;
    private int nextProjectileIndex;
    private bool shotAllowed = true;
	private string playerNumber;

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
		newProjectile = Instantiate(currentProjectile, transform.position, transform.rotation) as GameObject;
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

        if (shotAllowed && transform.root.tag == "Player1")
        {
            //Hold to charge up the shot's power (distance)
			if (Input.GetKey(p1Fire))
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
            if (Input.GetKeyUp(p1Fire))
            {
                ReleaseShot(currentCharge / maxCharge);
                currentCharge = 0;
                currentCooldown = 0;
                shotAllowed = false;
            }

			shootingCharge.value = (currentCharge / maxCharge) - minimumPercentage;
        }

		else if(shotAllowed && transform.root.tag == "Player2")

		{
			//Hold to charge up the shot's power (distance)
			if (Input.GetKey(p2Fire))
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
			if (Input.GetKeyUp(p2Fire))
			{
				ReleaseShot(currentCharge / maxCharge);
				currentCharge = 0;
				currentCooldown = 0;
				shotAllowed = false;
			}

			shootingCharge.value = (currentCharge / maxCharge) - minimumPercentage;
		}

        //Switch between weapons
        if (Input.GetKeyDown(weaponSwitchKey))
        {
            ChangeProjectile();
        }
	}
}