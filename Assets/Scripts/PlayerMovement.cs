using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;
    public float bounceForce = 6;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
        
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        Debug.Log(materialName);

        if (materialName == "SafeColor (Instance)")
        {
            // The ball hits the safe region
        }
        else if(materialName == "UnsafeColor (Instance)")
        {
            // The ball hits the unsafe region
            GameManager.gameOver = true;
            audioManager.Play("game over");
        }
        else if(materialName == "LastRing (Instance)" && !GameManager.levelComplete)
        {
            // level completed
            GameManager.levelComplete = true;
            audioManager.Play("win level");
        }
    }
}
