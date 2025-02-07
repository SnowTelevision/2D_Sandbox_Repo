using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.VFX.Utility;

public class JumpEvents : MonoBehaviour
{
    public TMP_Text jumpCountText; // The reference to the text UI element
    public AudioSource jumpSound; // Reference to the audio source object in the scene
    public VisualEffect jumpFX; // Reference to the VFX object
    public ExposedProperty spawnCount; // Store the name of the exposed parameter for the VFX graph
    public Transform playerChar; // Reference to the player character object's transform component

    public static JumpEvents instance; // Store the self reference
    public int jumpCount; // Store the counter for how many times the player have jumped

    // Start is called before the first frame update
    void Start()
    {
        instance = this; // Assign the self reference
        jumpCount = 0; // Reset the jump count to 0 everytime the game start
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JumpStart()
    {
        jumpCount++; // Increment the jump count when this function is called (it is called when player jumps)
        jumpCountText.text = jumpCount.ToString(); // Update the text in the text UI element
        jumpSound.Play(); // Play the jump sound once
        SpawnJumpVFX(); // Call the function that will create a VFX
    }

    public void SpawnJumpVFX()
    {
        jumpFX.SetInt(spawnCount, jumpCount); // Update the parameter in the VFX so it will create as many particles as the player have jumped
        Instantiate(jumpFX, playerChar.position - (Vector3.up * 0.5f), Quaternion.identity); // Create the VFX object at player character's feet
    }
}
