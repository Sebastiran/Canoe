using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour 
{
	public void OnButtonPress(int index)
	{
		SceneManager.LoadScene(index);
	}
}
