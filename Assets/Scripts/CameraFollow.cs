using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform ObjectToFollow;
    [SerializeField] float xMax;
    [SerializeField] float xMin;
    float zPos;
    float OffsetY;
    void Start()
    {
        zPos = transform.position.z;
        OffsetY = transform.position.y - ObjectToFollow.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(ObjectToFollow.position.x,ObjectToFollow.position.y + OffsetY,zPos);
        float xPos = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
    }
}
