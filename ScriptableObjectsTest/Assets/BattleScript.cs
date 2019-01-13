using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public Card card1;
    public Card card2;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            CheckJanKen();
        }
    }

    private void CheckJanKen()
    {
        if (card1.Jokenpo == JokenpoEnum.Rock)
        {
            if (card2.Jokenpo == JokenpoEnum.Rock) { Empate(); }
            else if (card2.Jokenpo == JokenpoEnum.Papper) { Debug.Log("Card 2 ganha"); }
            else if (card2.Jokenpo == JokenpoEnum.Scissors) { Debug.Log("Card 1 ganha"); }
        }
        else if (card1.Jokenpo == JokenpoEnum.Papper)
        {
            if (card2.Jokenpo == JokenpoEnum.Rock) { Debug.Log("Card 1 ganha"); }
            else if (card2.Jokenpo == JokenpoEnum.Papper) { Empate(); }
            else if (card2.Jokenpo == JokenpoEnum.Scissors) { Debug.Log("Card 2 ganha"); }
        }
        else if (card1.Jokenpo == JokenpoEnum.Scissors)
        {
            if (card2.Jokenpo == JokenpoEnum.Rock) { Debug.Log("Card 2 ganha"); }
            else if (card2.Jokenpo == JokenpoEnum.Papper) { Debug.Log("Card 1 ganha"); }
            else if (card2.Jokenpo == JokenpoEnum.Scissors) { Empate(); }
        }
    }

    private void Empate()
    {
        if (card1.Delay < card2.Delay)
        {
            Debug.Log("Card 1 delay " + card1.Delay);
            Debug.Log("Card 2 delay " + card2.Delay);
            Debug.Log("Card 1 ganha");
        }
        else if (card1.Delay > card2.Delay)
        {
            Debug.Log("Card 1 delay " + card1.Delay);
            Debug.Log("Card 2 delay " + card2.Delay);
            Debug.Log("Card 2 ganha");
        }
        else
        {
            Debug.Log("Empate");
        }
    }
}
