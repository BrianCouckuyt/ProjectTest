using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public float jumpForce = 400f;                          // Amount of force added when the player jumps.
    public float crouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    public float movementSmoothing = .05f;  // How much to smooth out the movement
    public bool airControl = false;                         // Whether or not a player can steer while jumping;

    bool isGrounded;            // Whether or not the player is grounded.
    Rigidbody2D m_Rigidbody2D;
    bool facingRight = true;  // For determining which way the player is currently facing.
    Vector3 velocity = Vector3.zero;


    bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = true;
    }


    public void Move(float move, bool isCrouching, bool isJumping)
    {
        //only control the player if grounded or airControl is turned on
        if (isGrounded || airControl)
        {

            // If crouching
            if (isCrouching)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= crouchSpeed;
            }
            else
            {

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            //else if (move < 0 && m_FacingRight)
            //{
            //    // ... flip the player.
            //    Flip();
            //}
        }
        // If the player should jump...
        if (isGrounded && isJumping)
        {
            // Add a vertical force to the player.
            isGrounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
