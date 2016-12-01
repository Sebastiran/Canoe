using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIscript : MonoBehaviour 
{
	public GameObject pOneWin, pOneLose, pTwoWin, pTwoLose, bgOverlay;
	public int playerIsWinner;
	public bool endGame;

	void Start()
	{
		playerIsWinner = 0;
		endGame = false;
	}
	// Update is called once per frame
	void Update ()
	{
		if (endGame)
			bgOverlay.SetActive(true);
		else
			bgOverlay.SetActive(false);

		switch (playerIsWinner)
		{
			case 0:
				pOneWin.SetActive(false);
				pOneLose.SetActive(false);
				pTwoWin.SetActive(false);
				pTwoLose.SetActive(false);
				break;
			case 1:
				pOneWin.SetActive(true);
				pTwoLose.SetActive(true);
				break;
			case 2:
				pOneLose.SetActive(true);
				pTwoWin.SetActive(true);
				break;
			default:
				break;
		}

	}
}
