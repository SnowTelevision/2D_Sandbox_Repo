using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public GameObject square; // Reference to the square object in our scene
    public float cameraMoveSpeed; // How fast the camera is moving

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacementToSquare = transform.position - square.transform.position; // Calculate the camera's relative position to the square
        displacementToSquare.z = 0;// Make sure the camera only move in the x-y plane
        Vector3 moveDir = displacementToSquare.normalized * -1;// Get the direction for the camera's movement
        Vector3 movement = moveDir * cameraMoveSpeed * Time.deltaTime; // Get how much the camera should move towards the square in this frame
        transform.position = transform.position + movement; // Move the camera
    }
}
