using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

    public float jumpHeight;

    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Jump () {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
    }

    void Attack () {
        
    }

    void Defense () {

    }

    void Grab () {

    }
}
