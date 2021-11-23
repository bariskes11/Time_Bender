using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{

    [SerializeField]
    float mouseSensitivity;
    [SerializeField]
    Camera camera;
    private float cameraPitch;
    private Vector3 lastPos;
    private Vector3 deltaPos;
    Joystick joystickInput;
    // Start is called before the first frame update
    void Start()
    {
   joystickInput=     GameObject.FindObjectOfType<Joystick>();

    }

    // Update is called once per frame
    void Update()
    {
      Vector2 mouseMovement=  MouseMovement();
        if (mouseMovement != Vector2.zero)
        {
            transform.localEulerAngles = new Vector3((mouseMovement.y) * mouseSensitivity

                , (-mouseMovement.x) * mouseSensitivity, transform.localEulerAngles.z);
        }
      //transform.localRotation=  Quaternion.Slerp(this.transform.localRotation, new Quaternion( joystickInput.Direction.x, 
      //    joystickInput.Direction.y, this.transform.localRotation.z, this.transform.localRotation.w),0.1F);
    }

    Vector3 MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaPos = lastPos - Input.mousePosition;

            return deltaPos;
        }

        return Vector3.zero;
    }
}
