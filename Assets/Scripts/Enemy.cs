using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject crashFX;
    [SerializeField] Transform parent;

	// Use this for initialization
	void Start ()
    {
        AddNonTriggerBoxCollider();
	}
	
    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(crashFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
}
