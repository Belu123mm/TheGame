﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

    public float speed = 8      //Bale pos no voy a decir nada, me gusta la idea pero kcyo dejame esta bien T.T
        , acceleration = 12
        , jumpForce = 10
        , currentSpeed
        , playerSpeed;
    private Player player;
    private Vector2 amountToMove;
    public bool ground,
        spammingSpace;

    void Start() {
        player = GetComponent<Player>();
    }
    
    void Update() {    
    }
    private void FixedUpdate()
    {      //Todas las funciones o cosas que tengan que ver con fisicas, aca. Tanto colisiones como movimiento o lo que sea 
        playerSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = Move(currentSpeed, playerSpeed, acceleration);       //Lo hace con aceleracion, esta a proposito? RTA: ¿Por? ¿Acaso afecta en algop?

        amountToMove = new Vector2(currentSpeed, 0);
        player.Move(amountToMove * Time.deltaTime);
        if (player.body.velocity.y < -0.1 && ground) {
            ground = false;
        } else ground = true;
        //Salto
        if (Input.GetButton("Jump") && !spammingSpace)        //Cambie esto, mirate el tema de los bools
        {
            float _tempJumpForce = jumpForce;
            player.Jump(_tempJumpForce);
            spammingSpace = true;
            
            if (spammingSpace)
            {
                _tempJumpForce -= 1;
            }
                    if (ground)
            {
                //spammingSpace = true;
                ground = false;
            }
        }
    }

    public float Move(float n, float target, float a) {
        if (n == target) return n;
        else if(!ground) {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            print(((dir == Mathf.Sign(target - n)) ? n : target));
            return ((dir == Mathf.Sign(target - n)) ? n : target);
        }
        else {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    void OnCollisionEnter2D(Collision2D c) {
        if(c.gameObject.layer == LayerMask.NameToLayer("Floor")) {
            // Delay to this ->
            player.body.velocity = Vector3.zero;
            player.body.angularVelocity = 0f;
            ground = true;
            spammingSpace = false;
        }
    }
}
