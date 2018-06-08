using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerScript : MonoBehaviour {

    public float jumpHeight;
    public LayerMask layerMask;
    public Effect effect;

    Rigidbody2D rb;

    RaycastHit2D hit;
    Ray2D ray;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Jump() {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
    }

    void Attack() {

    }

    void Defense() {

    }

    void Grab() {

    }

}
