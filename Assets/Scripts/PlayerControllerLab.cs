using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLab : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 10.0f;
    private Rigidbody playerRb;

    private float zBound = 7;
    private float xBound = 10;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        
        ConstraintPlayerPosition();
        
    }
    
    // Moves the player based on input keys
    void MovePlayer() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    
    // Prevents the player from leaving the screen
    void ConstraintPlayerPosition()
    {
        
        if (Mathf.Abs(transform.position.z) > zBound) {
            float dir = transform.position.z < 0 ? -1 : 1;
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound * dir);
        }
        if (Mathf.Abs(transform.position.x) > xBound) {
            float dir = transform.position.x < 0 ? -1 : 1;
            transform.position = new Vector3(xBound * dir, transform.position.y, transform.position.z);
        }
    }
}
