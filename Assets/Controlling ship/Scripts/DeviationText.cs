using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeviationText : MonoBehaviour
{
    public Text Z_Rotation, X_Rotation, Y_Rotation, X_Position, Y_Position, Z_Position, V_X, V_Y, V_Z;
    public double rotZ,rotX,rotY, posX,posY, posZ, normal_posX, normal_posY, normal_posZ;
    public GameObject ISS;
    private Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        normal_posX = ISS.transform.position.x-0.02;
        normal_posY = ISS.transform.position.y;
        normal_posZ = ISS.transform.position.z;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotZ = Math.Round(gameObject.transform.eulerAngles.z , 4);
        Z_Rotation.text =  rotZ.ToString("0.00");

        rotX = Math.Round(gameObject.transform.eulerAngles.x , 4);
        X_Rotation.text = rotX.ToString("0.00");

        rotY = Math.Round(gameObject.transform.eulerAngles.y , 4);
        Y_Rotation.text = rotY.ToString("0.00");

        posX = Math.Round(( normal_posX - gameObject.transform.position.x ), 4);
        X_Position.text = posX.ToString("0.00");

        posY = Math.Round((normal_posY - gameObject.transform.position.y) , 4);
        Y_Position.text = posY.ToString("0.00");

        posZ = Math.Round((normal_posZ- gameObject.transform.position.z) , 4);
        Z_Position.text = posZ.ToString("0.00");

        V_X.text = ((transform.position.x-oldPos.x)/Time.deltaTime).ToString("0.00");
        V_Y.text = ((transform.position.y-oldPos.y) / Time.deltaTime).ToString("0.00");
        V_Z.text = ((transform.position.z-oldPos.z) / Time.deltaTime).ToString("0.00");

        oldPos = gameObject.transform.position;
       
    }
}
