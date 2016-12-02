using UnityEngine;
using System.Collections;

public class PowerBox : MonoBehaviour {

    GameObject child;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

	public void Used()
    {
        child.SetActive(false);
        Invoke("Respawn", 5f);
    }

    void Respawn()
    {
        child.SetActive(true);
    }
}
