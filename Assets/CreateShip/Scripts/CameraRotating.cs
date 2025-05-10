using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRotating: MonoBehaviour
{
    [System.Serializable]
    public class SubList
    {
        public List<Transform> cameraStates = new List<Transform>();
    }
    public List<SubList> tables = new List<SubList>();
    public string[] tableNames;
    public GameObject cam;

    private int curentTableIndex;
    private int curentTransformIndex;
    [SerializeField] public MC_InGameInformation inf;
    private void Update()
    {
        if(inf.controlMode == 1)
        {
            if (Input.GetKeyDown(KeyCode.D)){
                curentTransformIndex --;
                if(curentTransformIndex < 0)
                {
                    curentTransformIndex = tables[curentTableIndex].cameraStates.Count-1;
                }
                ChangeCameraTransform(curentTableIndex, curentTransformIndex);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                curentTransformIndex++;
                if (curentTransformIndex >= tables[curentTableIndex].cameraStates.Count)
                {
                    curentTransformIndex = 0;
                }
                ChangeCameraTransform(curentTableIndex, curentTransformIndex );
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                inf.controlMode = 0;
                ChangeCameraTransform(0,0);
            }
        }
    }
    private void OnTriggerStay(Collider coll)
    {
        if (inf.controlMode == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                for (int i = 0; i < tableNames.Length; i++)
                {
                    if (coll.gameObject.name == tableNames[i])
                    {
                        //gameObject.name = tableNames[i];
                        ChangeCameraTransform(i+1, 0);
                        inf.controlMode = 1;
                        curentTableIndex = i+1;
                        curentTransformIndex = 0;
                    }
                }
            }
        }
    }
    void ChangeCameraTransform(int TableIndex, int TransIndex)
    {
        if (TableIndex < tables.Count)
        {
            if (TransIndex < tables[TableIndex].cameraStates.Count){
                cam.transform.position = tables[TableIndex].cameraStates[TransIndex].position;                                                                                             
                cam.transform.rotation = tables[TableIndex].cameraStates[TransIndex].rotation;
                cam.transform.localScale = tables[TableIndex].cameraStates[TransIndex].localScale;
            }
        }
    }
}
