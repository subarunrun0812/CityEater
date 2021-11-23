using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomInOut : MonoBehaviour
{
    float MouseZoomSpeed = 15.0f;
    float ZoomMinBound = 0.1f;
    float ZoomMaxBound = 179.9f;
    private Camera cam;

    void Update()
    {
        CameraZoom();
    }

    void CameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scroll, MouseZoomSpeed);
    }


    void Zoom(float deltaMagnitudeDiff, float speed)
    {
        cam.fieldOfView += deltaMagnitudeDiff * speed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, ZoomMinBound, ZoomMaxBound);
    }
}
