using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TesteScript : NetworkBehaviour {

	public GameObject cardPrefab;

    void Start() {
		if(hasAuthority){
			GameObject card = Instantiate(cardPrefab);
			NetworkServer.SpawnWithClientAuthority(card, connectionToClient);
		}
    }

    void Update() {
        
    }
}
