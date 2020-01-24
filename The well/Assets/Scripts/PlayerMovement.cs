using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    // Camera restrictions
    public float lookSensX = 15f;
    public float lookSensY = 15f;
    public float maxAngle = 85f;
    public float maxAngleY = 85f;

    private float angleX = 0;
    private float angleY = 0;

    public Transform body;

    public GameObject HookPivot;
    public GameObject Hook;

    void Update()
    {
        // Let you look around with your Mouse.
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        angleX += mouseX * lookSensX;
        angleY += mouseY * lookSensY;
        angleY = Mathf.Clamp(angleY, -maxAngleY, maxAngleY);

        body.transform.rotation = Quaternion.Euler(-angleY + 0, angleX + 180, +0);

        HookPivot.transform.rotation = Quaternion.Euler(-angleY + 0, angleX + 180, +0);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log("You selected the " + hit.transform.name);

                try
                {
                    hit.transform.GetComponent<ClickableInteraction>().Interact();
                }
                catch
                {
                    Debug.Log("Object clicked doesnt have an ClickableInteraction script. Continuing as normal.");
                }
            }
        }
    }

    /* 
     *  Going to keep this part around for later development
     *  
    void OnCollisionEnter(Collision col)
    {
        // Reloading the scene when you've fallen off the level.
        if (col.gameObject.tag == "Death")
        {
            SceneManager.LoadScene("Level");
        }
    }
    */
}