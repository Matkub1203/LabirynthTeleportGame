using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    float myAngle;

    void PortalCameraController()
    {
        Vector3 playerOffset = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffset;

        float angularDifference = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        if(myAngle == 90 || myAngle == 270)
        {
            angularDifference -= 90;
        }
        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifference, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * playerCamera.forward;
        if(myAngle == 90 || myAngle == 270)
        {
            newCameraDirection = new Vector3(-newCameraDirection.z, newCameraDirection.y, newCameraDirection.x);
        }
        else
        {
            newCameraDirection = new Vector3(-newCameraDirection.x, newCameraDirection.y, -newCameraDirection.z);
        }
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }

    private void Update()
    {
        PortalCameraController();
    }

    public void SetMyAngle(float angle)
    {
        myAngle = angle;
    }
}
