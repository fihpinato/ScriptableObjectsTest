using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

    public Effect effect;
    public GameObject player;
    public Animator playerAnim;

    public void DoEffect() {
        playerAnim.SetTrigger(effect.ToString());
    }
}

public enum Effect {
    Defense,
    Attack,
    Grab,
    Jump
}
