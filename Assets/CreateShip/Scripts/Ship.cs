using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Ship : MonoBehaviour
{
    public MC_InGameInformation inf;
    public int finalStage;
    public int shipNum;
    public List<GameObject> childrenDetails;
    private bool isFinished = false;
    public GameObject messegeUI;
    public Transform spawn;
    public static event Action<int> ShipCreated;
    public  void CreateShip()
    {
        ShipCreated.Invoke(shipNum);
        StartCoroutine(waitForAdding());
        isFinished = true;
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Table") && isFinished)
        {
            coll.gameObject.GetComponent<Table>().grabables.Add(gameObject);
        }
        if (coll.collider.CompareTag("Floor"))
        {
            gameObject.transform.position = spawn.transform.position; 
        }
    }
    private void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.name == "DeliveryTable" && Input.GetKey(KeyCode.E))
        {
            DeliverShip();
        }
    }
    private void DeliverShip()
    {
        messegeUI.SetActive(true);
        inf.shipsCreated++;
        Destroy(gameObject);
    }
    IEnumerator waitForAdding()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        gameObject.GetComponent<ThrowableObject>().enabled = true;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
