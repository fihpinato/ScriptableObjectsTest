using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "ScriptableObject/Character")]
public class CharacterSheet : ScriptableObject {

    public new string name;
    public int hp;

}
