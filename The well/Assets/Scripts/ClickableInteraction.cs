using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableInteraction : MonoBehaviour
{
    public int typeOfInteraction;

    public void Interact()
    {
        switch(typeOfInteraction)
        {
            case 1:
                Debug.Log('1');
                break;

            case 2:
                Debug.Log('2');
                Destroy(gameObject);
                break;
        }
    }
}
