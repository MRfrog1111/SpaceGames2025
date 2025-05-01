using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public GameObject mc;
    public GameObject mainCamera;
    float deltaPlane;
    float distance;
    Vector3 point;
    public float rotationSpeed;
    public  bool isChosen = false;
    private void Update()
    {
        if (mc.GetComponent<MC_InGameInformation>().controlMode == 1)
        {
            if (Input.GetMouseButton(1) && isChosen)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                print(mainCamera.transform.eulerAngles.y);
                if ((mainCamera.transform.eulerAngles.y >= -1 && mainCamera.transform.eulerAngles.y <= 1) || (mainCamera.transform.eulerAngles.y >= 179 && mainCamera.transform.eulerAngles.y <= 181))
                {
                    transform.Rotate((Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), 0, Space.World);
                }
                else
                {
                    transform.Rotate((Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime), 0, Space.World);
                }
            }
            else if (!Input.GetMouseButton(0))
            {
                isChosen = false;
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
    private void OnMouseDrag()
    {
        if (mc.GetComponent<MC_InGameInformation>().controlMode == 1)
        {
            isChosen = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if ((mainCamera.transform.eulerAngles.y >= -1 && mainCamera.transform.eulerAngles.y <= 1) || (mainCamera.transform.eulerAngles.y >= 179 && mainCamera.transform.eulerAngles.y <= 181))
            {
                deltaPlane = transform.position.z;
                distance = (deltaPlane - ray.origin.z) / ray.direction.z;
                point = ray.origin + ray.direction * distance;
                point.z = deltaPlane;
            }
            else
            {
                deltaPlane = transform.position.x;
                distance = (deltaPlane - ray.origin.x) / ray.direction.x;
                point = ray.origin + ray.direction * distance;
                point.x = deltaPlane;
            }
            transform.position = point;
        }
    }
}
