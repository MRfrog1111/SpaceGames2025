using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Moving : MonoBehaviour
{
    public float speedSides; 
    public float rotationSpeed; 
    public float speedGoing; 
    public float rotatingSpeed;
    public float spreadStartPosition;
    public float spreadStartRotation;
    Vector3 startPos, startRot;
    bool isInStartPosition = false;
    public float speed;
    Vector3 rotZ = new Vector3(0f, 0f, 1f);
    private int timer = 0;
    public Text endingText;
    public GameObject endingUI;
    public GameObject mainUI;
    public GameObject centerUI;
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(Random.Range(-spreadStartPosition, spreadStartPosition), Random.Range(-spreadStartPosition, spreadStartPosition), Random.Range(-spreadStartPosition, spreadStartPosition));
        startRot = new Vector3(Random.Range(-spreadStartRotation, spreadStartRotation), Random.Range(-spreadStartRotation, spreadStartRotation), Random.Range(-spreadStartRotation, spreadStartRotation));
    }

    private void FixedUpdate()
    {
        if (timer < 60)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime*speed);
            transform.eulerAngles = Vector3.RotateTowards(transform.position, startRot, Time.deltaTime*speed, speed);
            timer++;
        }
        else
        {
            //Moving
            //left
            if (Input.GetKeyUp(KeyCode.A))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * speedSides * Time.deltaTime);
            }
            //right
            if (Input.GetKeyUp(KeyCode.D))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * speedSides * Time.deltaTime);
            }
            //up
            if (Input.GetKeyUp(KeyCode.W))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speedSides * Time.deltaTime);
            }
            //down
            if (Input.GetKeyUp(KeyCode.S))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.down * speedSides * Time.deltaTime);
            }
            //forward
            if (Input.GetKeyUp(KeyCode.E))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * speedGoing * Time.deltaTime);
            }
            //back
            if (Input.GetKeyUp(KeyCode.F))
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * speedGoing * Time.deltaTime);
            }
            //Rotating 
            //up
            if (Input.GetKeyDown(KeyCode.I))
            {
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.left * rotationSpeed * Time.deltaTime);
            }
            //down
            if (Input.GetKeyDown(KeyCode.K))
            {
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * rotationSpeed * Time.deltaTime);
            }
            //left
            if (Input.GetKeyDown(KeyCode.J))
            {
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.down * rotationSpeed * Time.deltaTime);
            }
            //right
            if (Input.GetKeyDown(KeyCode.L))
            {
                gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                gameObject.GetComponent<Rigidbody>().AddTorque(rotZ * rotatingSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                gameObject.GetComponent<Rigidbody>().AddTorque(-rotZ * rotatingSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        Time.timeScale = 0;
        mainUI.SetActive(false);
        centerUI.SetActive(false);
        endingUI.SetActive(true);
        if (coll.name == "WinPoint")
        {
            if ((gameObject.GetComponent<DeviationText>().rotX / 360 <= 0.03 ||
                 gameObject.GetComponent<DeviationText>().rotX / 360 >= 0.97) &&
                (gameObject.GetComponent<DeviationText>().rotY / 360 <= 0.03 ||
                 gameObject.GetComponent<DeviationText>().rotY / 360 >= 0.97))
            {
                endingText.text = "Стыковка успешно состоялась!";

            }
            else
            {
                
                endingText.text = "Стыковка провалилась!";
            }
        }
        else
        {
            endingText.text = "Стыковка провалилась!";
        }
    }
}
