using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnManager : MonoBehaviour {

    #region SINGLETON
    public static TurnManager _instance;
    public static TurnManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<TurnManager>();
                if (_instance == null) {
                    GameObject container = new GameObject("TurnManager");
                    _instance = container.AddComponent<TurnManager>();
                }
            }
            return _instance;
        }
    }

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public Turn turn;

    public TMP_Text enemyPontuationText;
    public TMP_Text playerPontuationText;

    private void Start () {

    }

    public void NextTurn () {
        switch (turn) {
            case Turn.Player:
                turn = Turn.Enemy;
                break;
            case Turn.Enemy:
                turn = Turn.Result;
                break;
            case Turn.Result:
                turn = Turn.Player;
                break;
        }
    }

    private void Update () {
        if (Input.GetButtonDown("Jump")) {
            NextTurn();
        }
    }

}

public enum Turn {
    Player,
    Enemy,
    Result
}


