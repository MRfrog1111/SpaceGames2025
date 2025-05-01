using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : ThrowableObject
{
    public string schemeDetailName;
    private bool isRotated = false;
    private bool flag = false;
    GameObject go;
    public int shipNum;
    public Transform spawn;
    private bool isEntered = false;
    void MakePassive(int num)
    {
        if (num == shipNum)
        {
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<BoxCollider>());
            Destroy(GetComponent<Detail>());
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("SchemeDetail") && coll.gameObject.name == schemeDetailName)
        {
            if (!isChosen)
            {
                isEntered = true;
                gameObject.transform.position = coll.gameObject.transform.position;
                gameObject.transform.parent = coll.gameObject.transform.parent;
                coll.gameObject.GetComponent<MeshRenderer>().enabled = false;
                coll.GetComponentInParent<Ship>().childrenDetails.Add(gameObject);
                coll.gameObject.name += "-";
                isEntered = true;
                if (coll.GetComponentInParent<Ship>().childrenDetails.Count == coll.GetComponentInParent<Ship>().finalStage)
                {
                    gameObject.transform.rotation = coll.gameObject.transform.rotation; ;
                    coll.GetComponentInParent<Ship>().CreateShip();
                }
            }
        }
    }
    private void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("SchemeDetail") && coll.gameObject.name  == schemeDetailName + "-" && isEntered)
        {
            print("a");
            if (!isChosen)
            {
                gameObject.transform.position = coll.gameObject.transform.position;
                if (Mathf.Abs(gameObject.transform.rotation.x % 360 / coll.transform.rotation.x % 360) > 5 || Mathf.Abs(gameObject.transform.rotation.y % 360 / coll.transform.rotation.y % 360) > 5 || Mathf.Abs(gameObject.transform.rotation.z % 360 / coll.transform.rotation.z % 360) > 5)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, coll.transform.rotation, 10.0f);
                }
                else if (!isRotated)
                {
                    gameObject.transform.rotation = coll.gameObject.transform.rotation;
                    isRotated = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("SchemeDetail") && coll.gameObject.name == schemeDetailName + "-" && isEntered)
        {
            isEntered = false;
            coll.gameObject.name = schemeDetailName;
            gameObject.transform.parent = null;
            coll.gameObject.GetComponent<MeshRenderer>().enabled = true;
            coll.GetComponentInParent<Ship>().childrenDetails.Remove(gameObject);
            isRotated = false;
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Floor"))
        {
            gameObject.transform.position = spawn.transform.position; 
        }
    }
    private  void FixedUpdate()
    {
        Ship.ShipCreated += MakePassive;
    }
}
