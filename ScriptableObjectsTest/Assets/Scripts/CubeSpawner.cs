using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    ObjectPooler objectPooler;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update() {
        objectPooler.SpawnFromPool("Cube", transform.position, transform.rotation);
    }

}
