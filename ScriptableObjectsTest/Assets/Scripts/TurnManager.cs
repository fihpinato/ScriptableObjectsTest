using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [System.Serializable]
    public class Player {
        public CharacterSheet character;
        public int hp;
        public GameAreaScript gameArea;
        public TMP_Text delayText;
        public Slider slider;
        public Transform spawnPoint;
        public int delay;
        public Vector3 pos;
        public List<Card> deck;
        public List<Transform> activeCards;

        public void DiscartCard() {
            gameArea.hasCard = false;
            gameArea.card = null;
            gameArea.cardDisplay = null;
            gameArea.cardObject.SetActive(false);
            gameArea.cardObject = null;
        }

        public void RefreshHud() {
            delayText.text = "Delay: " + delay;
            slider.value = hp;
        }

        public void GetDamage(int damage) {
            hp -= damage;
        }

        public void InitStats() {
            slider.maxValue = character.hp;
            hp = character.hp;
        }

        public void MovementCards() {
            for (int i = 0; i < activeCards.Count; i++) {
                Vector3 playerCardPos = activeCards[i].position;
                Vector3 fixedPos = new Vector3(spawnPoint.position.x + (pos.x * i), spawnPoint.position.y, spawnPoint.position.z);
                activeCards[i].position = Vector3.Lerp(activeCards[i].position, fixedPos, .1f);
            }
        }

        public void DrawCard(Vector3 newPos, string poolName) {
			
        }
    }

    public List<Player> players;

    public int cardToSpawnOnStart = 5;

    private void Start() {
        players[0].InitStats();
        players[1].InitStats();
        SpawnFirstCards();
    }

    private void Update() {
        players[0].MovementCards();
    }

    private void SpawnFirstCards() {
        for (int i = 0; i < cardToSpawnOnStart; i++) {
            Vector3 newPos = new Vector3(i * 3, 0f, 0f);
            players[0].DrawCard(newPos, "CardP0");
        }

        for (int i = 0; i < cardToSpawnOnStart; i++) {
            Vector3 newPos = new Vector3(i * 3, 0f, 0f);
            players[1].DrawCard(newPos, "CardP1");
        }
    }

    public void GetOutCardOfList(Transform cardToRemove) {
        if (players[0].activeCards.Contains(cardToRemove)) {
            players[0].activeCards.Remove(cardToRemove);
        }

        if (players[1].activeCards.Contains(cardToRemove)) {
            players[1].activeCards.Remove(cardToRemove);
        }
    }

    public void AddCardInList(Transform cardToAdd) {
        players[0].activeCards.Add(cardToAdd);
    }


    private void CompareCards() {

        if (players[0].gameArea.card.jokenpo == players[1].gameArea.card.jokenpo) {
            Tie();
        }

        if (players[0].gameArea.card.jokenpo == Jokenpo.Rock) {
            switch (players[1].gameArea.card.jokenpo) {
                case Jokenpo.Papper:
                    P1Win();
                    break;
                case Jokenpo.Scissors:
                    P0Win();
                    break;
            }
        }

        if (players[0].gameArea.card.jokenpo == Jokenpo.Papper) {
            switch (players[1].gameArea.card.jokenpo) {
                case Jokenpo.Scissors:
                    P1Win();
                    break;
                case Jokenpo.Rock:
                    P0Win();
                    break;
            }
        }

        if (players[0].gameArea.card.jokenpo == Jokenpo.Scissors) {
            switch (players[1].gameArea.card.jokenpo) {
                case Jokenpo.Rock:
                    P1Win();
                    break;
                case Jokenpo.Papper:
                    P0Win();
                    break;
            }
        }

        DiscartCards();
        RefreshHuds();
        DrawCards(Vector3.zero);
    }

    void DrawCards(Vector3 newPos) {
        players[0].DrawCard(newPos, "CardP0");
        players[1].DrawCard(newPos, "CardP1");
    }

    void DiscartCards() {
        players[0].DiscartCard();
        players[1].DiscartCard();
    }

    void Combo() {

    }

    void Tie() {
        if (players[0].gameArea.card.delay < players[1].gameArea.card.delay) {
            P0Win();
        } else if (players[1].gameArea.card.delay < players[0].gameArea.card.delay) {
            P1Win();
        } else {
            players[0].delay = 0;
            players[1].delay = 0;
            print("a tie");
        }
    }

    void P0Win() {
        if (players[1].delay != 0) {
            players[0].delay = 0;
            players[1].delay = players[0].gameArea.card.delayOnHit;
            players[1].GetDamage(players[0].gameArea.card.damage);
        } else {
            players[0].delay = 0;
            players[1].delay = players[0].gameArea.card.delayOnBlock;
        }
        print("P0 Win");
    }

    void P1Win() {
        if (players[0].delay != 0) {
            players[0].delay = players[1].gameArea.card.delayOnHit;
            players[0].GetDamage(players[1].gameArea.card.damage);
            players[1].delay = 0;
        } else {
            players[0].delay = players[1].gameArea.card.delayOnBlock;
            players[1].delay = 0;
        }
        print("P1 Win");
    }

    void RefreshHuds() {
        players[0].RefreshHud();
        players[1].RefreshHud();
    }

}


