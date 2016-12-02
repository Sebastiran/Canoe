using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
	[SerializeField] Slider healthBar;
	[SerializeField] GameObject pOneWin, pTwoWin, otherPlayer;

    void Start()
    {
        currentHealth = maxHealth;
    }

	void Update()
	{ 
		healthBar.value = (currentHealth / 100.0f);
	}

    public void ApplyDamage(float damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    void PlayerDeath()
    {
        Debug.Log("Blub!");
		GetComponent<CanoeController>().enabled = false;

		if (gameObject.name == "Canoe 1")
		{
			pTwoWin.SetActive(true);
			otherPlayer.GetComponent<CanoeController>().enabled = false;
			otherPlayer.GetComponentInChildren<ShootingControls>().enabled = false;
		}
		else if (gameObject.name == "Canoe 2")
		{
			pOneWin.SetActive(true);
			otherPlayer.GetComponent<CanoeController>().enabled = false;
			otherPlayer.GetComponentInChildren<ShootingControls>().enabled = false;
		}
    }
}