using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public TMP_Text cardNameText;

    GameObject player;
    Animator playerAnim;

    void Start() {
        cardNameText.text = card.effect.ToString();

        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();

        card.player = player;
        card.playerAnim = playerAnim;
    }

    private void OnMouseDown() {
        card.DoEffect();
    }
}
