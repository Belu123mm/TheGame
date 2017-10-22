using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

    public float speed = 8
        , acceleration = 12
        , jumpForce = 500f
        , currentSpeed
        , playerSpeed;
    private Player player;
    private Vector2 amountToMove;
    public bool ground;
    public bool spammingSpace;

    // Use this for initialization
    void Start() {
        player = GetComponent<Player>();
    }
    
    // Update is called once per frame
    void Update() {
        playerSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = Move(currentSpeed, playerSpeed, acceleration);

        amountToMove = new Vector2(currentSpeed, 0);
        player.Move(amountToMove * Time.deltaTime);
        if(player.body.velocity.y < -0.1 && ground) {
            ground = false;
        }
        if(Input.GetAxis("Jump") == 1) {
            if(ground) {
                ground = false;
                //spammingSpace = true;
                player.Jump(jumpForce);
            }
        }
    }

    public float Move(float n, float target, float a) {
        if (n == target) return n;
        else {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    void OnCollisionEnter2D(Collision2D c) {
        if(c.gameObject.tag == "Collision") {
            // Delay to this ->
            player.body.velocity = Vector3.zero;
            player.body.angularVelocity = 0f;
            ground = true;
            spammingSpace = false;
        }
    }
}
