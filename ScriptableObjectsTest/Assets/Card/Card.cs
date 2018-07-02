using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObject/Card")]
public class Card : ScriptableObject {
    public new string name;
    public Jokenpo jokenpo;
    public int delay = 1;
    public int delayOnHit;
    public int delayOnBlock;
    public int damage;
}

public enum Jokenpo {
    Rock,
    Papper,
    Scissors
}
