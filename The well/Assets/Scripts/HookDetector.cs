using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            Player.GetComponent<Hooked>().hooked = true;
            Player.GetComponent<Hooked>().hookedObj = other.gameObject;
        }
    }
}