using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public TMP_Text cardNameText;

    public GameObject player;
    public Animator playerAnim;

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
