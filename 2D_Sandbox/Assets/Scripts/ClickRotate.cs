using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRotate : MonoBehaviour
{
    public float force;
    public CameraFollow camControl;
    public Transform playerChar;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        rb.AddForceAtPosition(Vector3.up * force, playerChar.position + Vector3.down * 2, ForceMode2D.Impulse);

        camControl.enabled = false;
    }
}
