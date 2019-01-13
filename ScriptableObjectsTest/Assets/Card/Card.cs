using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObject/Card")]
public class Card : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private JokenpoEnum _jokenpo;
    [SerializeField]
    private int _delay;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _advantageOnWin;
    [SerializeField]
    private int _advantageOnLose;

    public string Name { get { return _name; } private set { Name = _name; } }
    public JokenpoEnum Jokenpo { get { return _jokenpo; } private set { Jokenpo = _jokenpo; } }
    public int Delay { get { return _delay; } private set { Delay = _delay; } }
    public int Damage { get { return _damage; } private set { Damage = _damage; } }
    public int AdvantageOnWin { get { return _advantageOnWin; } private set { AdvantageOnWin = _advantageOnWin; } }
    public int AdvantageOnLose { get { return _advantageOnLose; } private set { AdvantageOnLose = _advantageOnLose; } }
}

public enum JokenpoEnum
{
    Rock,
    Papper,
    Scissors
}
