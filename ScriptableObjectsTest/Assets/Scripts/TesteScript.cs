using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteScript : MonoBehaviour {

    public Vector3 min;
    public Vector3 max;
    public List<Transform> cards;

    void Start() {

    }

    void Update() {
        if (cards.Count == 1) {
            cards[0].position = transform.position;
        } else {
            for (int i = 0; i < cards.Count; i++) {
                if (i > 1) {
                    print(Vector3.Distance(cards[i].position, cards[i - 1].position));
                    if (Vector3.Distance(cards[i].position, cards[i - 1].position) < 10f) {
                        cards[i].position = (cards[i].position - cards[i - 1].position).normalized * max.x + cards[i - 1].position;
                    }
                }
            }
        }
    }
}
