using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    BoxCollider2D myFeet;
    [SerializeField] float walkSpeed = 3f;
    [SerializeField] float jumpHigh = 5f;
    [SerializeField] float climbSpeed = 3;
    float gravityScaleStart;


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Climb();
    }

    private void Move()
    {
        float control = CrossPlatformInputManager.GetAxis("Horizontal") * walkSpeed;
        myRigidbody.velocity = new Vector2( control, transform.position.y);
    }
    private void Climb()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidbody.gravityScale = gravityScaleStart;
            return;
        }
            float climbForce = CrossPlatformInputManager.GetAxis("Vertical");
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, climbForce * climbSpeed); 
            myRigidbody.gravityScale=0f;
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"))) { return; }
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 addForce = new Vector2( 0f, jumpHigh);
            myRigidbody.velocity = addForce;
        }
    }

}

