using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour
{
    private float defaultZPos;
    private Transform camera;

    private void Start()
    {
        camera = Camera.main.transform;
        defaultZPos = transform.localPosition.z;
    }

    private void Update()
    {
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.distance > defaultZPos)
            {
                transform.localPosition = new Vector3(0, 0, hit.distance * 0.95f);
            }

            else
            {
                transform.localPosition = new Vector3(0, 0, defaultZPos);
            }
        }
    }
}
