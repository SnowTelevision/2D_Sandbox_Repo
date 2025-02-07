using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX.Utility;
using UnityEngine.VFX;

public class NewJumpEvents : MonoBehaviour
{
    public TMP_Text jumpCountText;
    public AudioSource jumpSound;
    public VisualEffect jumpFX;
    public ExposedProperty spawnCount;
    public Transform playerChar;

    public static NewJumpEvents instance;
    public int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JumpStart()
    {
        jumpCount++;
        jumpCountText.text = jumpCount.ToString();
        jumpSound.Play();
        SpawnJumpVFX();
    }

    public void JumpEnd()
    {
    }

    public void SpawnJumpVFX()
    {
        jumpFX.SetInt(spawnCount, jumpCount);
        Instantiate(jumpFX, playerChar.position - (Vector3.up * 0.5f), Quaternion.identity);
    }
}
