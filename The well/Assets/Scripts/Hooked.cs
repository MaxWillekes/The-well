using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooked : MonoBehaviour
{
    public GameObject hook;
    public GameObject HookPivot;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public static bool fired;
    public bool hooked;
    public GameObject hookedObj;

    public float maxDistance;
    private float currentDistance;

    private void Update()
    {
        // Firing the hook
        if (Input.GetMouseButtonDown(0) && fired == false)
        {
            fired = true;
        }

        if (fired == true && hooked == false)
        {
            hook.transform.Translate(Vector3.forward * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);

            if (currentDistance >= maxDistance)
            {
                ReturnHook();
            }
        }

        // Transport player to Hook Posistion
        if (hooked == true)
        {
            hook.transform.parent = hookedObj.transform;
            Vector3 hookPosition = Vector3.Scale(hook.transform.position, new Vector3(1, 0, 1));
            transform.position = Vector3.MoveTowards(transform.position, hookPosition, Time.deltaTime * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hookPosition);

            GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 0.25)
            {
                ReturnHook();
            }
        }
        else
        {
            hook.transform.parent = HookPivot.transform;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // Returns Hook to Player
    void ReturnHook()
    {
        hook.transform.rotation = HookPivot.transform.rotation;
        hook.transform.position = HookPivot.transform.position;
        fired = false;
        hooked = false;
    }
}