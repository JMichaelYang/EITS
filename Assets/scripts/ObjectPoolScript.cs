using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolScript : MonoBehaviour
{
    public static ObjectPoolScript instance;

    public GameObject bullet;

    public int defaultPooledAmount = 500;

	// Use this for initialization
	void Start () {
	
	}

    //set instance to itself
    void Awake()
    {
        ObjectPoolScript.instance = this;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
