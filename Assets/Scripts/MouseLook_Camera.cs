
using UnityEngine;

public class MouseLook_Camera : MonoBehaviour
{
    public RotationalAxis axis = RotationalAxis.MouseX;

    [Range(0, 20)]
    public float sensitivityX = 15;
    [Range(0, 20)]
    public float sensitivityY = 15;

    public float minY = -60;
    public float maxY = 60;

    float rotationY = 0;
    void Start()
    {
        if (this.GetComponent<Rigidbody>())
        {
            this.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }
    void Update()
    {

        if (axis == RotationalAxis.MouseXandY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        else if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }

        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }

    }
}
public enum RotationalAxis
{
    MouseXandY = 0,
    MouseX,
    MouseY
}