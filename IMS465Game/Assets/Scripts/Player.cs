using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Movement")]
    [Tooltip("Change how fast the Player moves"), Min(0), SerializeField] 
    private float speed = 1f;

    [Tooltip("How far up the player can move"), SerializeField] 
    private float UpLimit = -1;
    [Tooltip("How far down the player can move"), SerializeField]
    private float DownLimit = -2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gets the movement working
        Movement();
    }

    /// <summary>
    /// Movement of the Player
    /// </summary>
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // -1 -> 1 horizontal input movement
        float verticalInput = 0; // 0 to set standing still

        // vetical input movement
        if (transform.position.y <= UpLimit && transform.position.y >= DownLimit) // if in the middle and all good
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                verticalInput = -1;

                if (Input.GetKey(KeyCode.W))
                {
                    verticalInput = 0;
                }
            }
        }
        else if (transform.position.y > UpLimit && transform.position.y >= DownLimit) // if too high
        {
            if (Input.GetKey(KeyCode.S))
            {
                verticalInput = -1;
            }
        }
        else if (transform.position.y <= UpLimit && transform.position.y < DownLimit) // if too low
        {
            if (Input.GetKey(KeyCode.W))
            {
                verticalInput = 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyDown(KeyCode.S)) // if not moving
        {
            verticalInput = 0;
        }

        // allows for the horizontal and vertical movement
        transform.Translate(Vector2.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector2.up * speed/2 * verticalInput * Time.deltaTime);
    }
}
