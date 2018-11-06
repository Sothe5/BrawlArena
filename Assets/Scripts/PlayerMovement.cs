using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Range(1, 2)]
    public int playerNumber;
    public float speed;
    public float jumpForce = 10;

    private Rigidbody2D myRigidbody;
    private Vector2 velocity;
    private float remainTimeJump = 10;
    private int jumpRemaining = 3;
    private bool onGround = true;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {

        myRigidbody.velocity = velocity;
        float horizontalDir = Input.GetAxisRaw("Horizontal" + playerNumber);

        velocity.x = speed * horizontalDir;

        remainTimeJump -= 1;

        if (Input.GetKeyDown(KeyCode.W) && jumpRemaining > 0) {
            velocity.y = jumpForce;
            remainTimeJump = 10;
            jumpRemaining--;
            if (jumpRemaining <= 0) {
                GetComponent<AlfaOfPlayer>().turnAlfaDown();
            }
        } else {
            if (remainTimeJump <= 0 && velocity.y <= 0) {
                velocity.y = 0;
            } else {
                velocity.y -= 1f;
            }
        }

        if (Input.GetKey(KeyCode.S) && !onGround) {
            myRigidbody.gravityScale = 60;
        } else {
            myRigidbody.gravityScale = 40;
        }


    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            onGround = true;
            jumpRemaining = 3;
            GetComponent<AlfaOfPlayer>().turnAlfaUp();
        }
    }

    // tiene pinta que el onground no se actualiza como debe
    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            onGround = false;
        }
    }
}