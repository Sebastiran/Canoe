using UnityEngine;
using System.Collections;

public class TreeSpawn : MonoBehaviour 
{
	[SerializeField] GameObject tree;
	GameObject[] treeLine;
	int max = 360;
	float r1 = 360.0f;
	float r2 = 380.0f;

	// Use this for initialization
	void Awake () 
	{
		for (int i = 0; i < max; i++)
		{
			GameObject clone1 = Instantiate(tree, new Vector3(((r1 + Random.Range(-1f, 1f)) * Mathf.Cos(i) + Random.Range(-1f, 1f)), 5.5f, ((r1 + Random.Range(-1f, 1f)) * Mathf.Sin(i) + Random.Range(-1f, 1f))), Quaternion.identity) as GameObject;
			GameObject clone2 = Instantiate(tree, new Vector3(((r2 + Random.Range(-1f, 1f)) * Mathf.Cos(i) + Random.Range(-1f, 1f)), 6.5f, ((r2 + Random.Range(-1f, 1f)) * Mathf.Sin(i) + Random.Range(-1f, 1f))), Quaternion.identity) as GameObject;
			float scaleFactor1 = Random.Range(10.0f, 20.0f);
			float scaleFactor2 = Random.Range(35.0f, 45.0f);
			float rotDiff1 = Random.Range(0.0f, 45.0f);
			float rotDiff2 = Random.Range(0.0f, 45.0f);
			clone1.transform.localScale = new Vector3(scaleFactor1, scaleFactor1, scaleFactor1);
			clone1.transform.rotation = Quaternion.Euler(0.0f, rotDiff1, 0.0f);
			clone2.transform.localScale = new Vector3(scaleFactor2, scaleFactor2, scaleFactor2);
			clone2.transform.rotation = Quaternion.Euler(0.0f, rotDiff2, 0.0f);
			clone1.transform.parent = gameObject.transform;
			clone2.transform.parent = gameObject.transform;
			//byte green1 = (byte)Random.Range(50, 255);
			//byte green2 = (byte)Random.Range(50, 255);
			//MeshRenderer rnd1 = clone1.GetComponentInChildren<MeshRenderer>();
			//MeshRenderer rnd2 = clone1.GetComponentInChildren<MeshRenderer>();
			//rnd1.material.color = new Color32(50, green1, 75, 255);
			//rnd2.material.color = new Color32(50, green2, 75, 255);
		}
	}
}