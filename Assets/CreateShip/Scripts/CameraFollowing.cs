using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    private Vector3 offcet;
    public GameObject mc;
    [SerializeField] private float smoothTime;
    private Vector3 speed = Vector3.zero;
    private  Transform mc_transform;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxZ;
    [SerializeField] private float minZ;
    private Vector3 mc_pos;
    private void Awake()
    {
        mc_pos = mc.transform.position;
        offcet = transform.position - mc_pos;
    }

    private void LateUpdate()
    {
        if (mc.GetComponent<MC_InGameInformation>().controlMode == 0)
        {
            mc_pos = mc.transform.position;
            if (minX > mc_pos.x)
            {
                mc_pos.x = minX;
            }
            if ( maxX < mc_pos.x)
            {
                mc_pos.x = maxX;
            }
            if (minZ > mc_pos.z)
            {
                mc_pos.z = minZ;
            }
            if (maxZ < mc_pos.z)
            {
                mc_pos.z = maxZ;
            }
            Vector3 targetPos = mc_pos + offcet;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothTime);
        }
    }

}
