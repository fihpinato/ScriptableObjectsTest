using UnityEngine;

public class GameAreaScript : MonoBehaviour {

    public GameObject cardObject;
    public CardDisplay cardDisplay;
    public Card card;
    public bool hasCard;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Finish") && !hasCard) {
            cardObject = other.gameObject;
            cardDisplay = other.GetComponent<CardDisplay>();
            card = cardDisplay.card;
        }
    }
}
