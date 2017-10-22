using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class Player : MonoBehaviour {

    public Rigidbody2D body;

    public void Start() {
        body = this.GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveAmount) {
        transform.Translate(moveAmount);
    }

    public void Jump(float jumpForce) {
        //body.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        body.AddForce(Vector2.up * jumpForce);
    }

}
