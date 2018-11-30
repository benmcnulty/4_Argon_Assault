using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        print("Player Triggered: " + other);
        SendMessage("PlayerCrashed");
    }

    void PlayerCrashed()
    {
        print("No more triggers");
    }
}
