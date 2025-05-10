using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_base: MonoBehaviour
{
    public float runningSpeed;
    private Rigidbody rb;
    public bool isGrabbing = false;
    public  GameObject grabObj;
    [SerializeField] public MC_InGameInformation inf;
    [SerializeField] private Transform grabTransform;
    private GameObject tableObj;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if(inf.controlMode == 0)
        {
            Move();
            Grab();
        }     
    }
    private void Move()
    {
        Vector3 mc_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + mc_Input * runningSpeed * Time.deltaTime);
      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
    private void Grab()
    {
        if (Input.GetKeyUp(KeyCode.E) &&  inf.controlMode == 0 && (grabObj != null || (tableObj != null && tableObj.GetComponent<Table>().grabables.Count > 0)))
        {
            
            if (tableObj.GetComponent<Table>().grabables.Count > 0)
            {
                grabObj = tableObj.GetComponent<Table>().grabables[0];
            }
            if (isGrabbing)
            {
                grabObj.transform.parent = null;
                grabObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                isGrabbing = false;
            }
            else
            {
                grabObj.transform.parent = gameObject.transform;
                isGrabbing = true;
                grabObj.transform.position = grabTransform.position;
                grabObj.transform.rotation = grabTransform.rotation;
                grabObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (!isGrabbing)
        {
            if (coll.collider.CompareTag("Grabable"))
            {
                grabObj = coll.collider.gameObject;
               
            }
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (!isGrabbing)
        {
            if (coll.CompareTag("Table"))
            {
                tableObj = coll.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Table"))
        {
            tableObj = null;
        }
    }
    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("Grabable") && !isGrabbing)
        {
            grabObj = null;
        }
    }
}
