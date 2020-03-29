using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform mainCharacterTransform;
    private Transform backgroundTransform;
    private float offsetX;
    private float offsetY;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCharacterTransform = GameObject.FindGameObjectWithTag("Main Character").transform;
        backgroundTransform = GameObject.FindGameObjectWithTag("Background").transform;
        offsetX = 1.4f;
        offsetY = 0.3f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = mainCharacterTransform.position.x + offsetX;
        cameraPosition.y = mainCharacterTransform.position.y + offsetY;
        transform.position = cameraPosition;
    }
}
