using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Vector3 maxSize;
    public Vector3 minSize;
    public float timeToTransform;

    public TMP_Text cardNameText;

    GameObject player;
    Animator playerAnim;
    bool mouseUp = false;

    void Start() {
        cardNameText.text = card.effect.ToString();

        //player = GameObject.FindGameObjectWithTag("Player");
        //playerAnim = player.GetComponent<Animator>();
        //card.playerAnim = playerAnim;
    }

    private void Update() {
        TransformCardSize();

        
    }

    void TransformCardSize () {
        Vector3 newSize;
        if (mouseUp) {
            newSize = maxSize;
        } else {
            newSize = minSize;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, newSize, Time.deltaTime * 5f);
    }

    void DoSomething () {
        if (TurnManager.Instance.turn == Turn.Player) {
            card.DoEffect();
            TurnManager.Instance.NextTurn();
        }
    }

    private void OnMouseDown() {
        
    }

    private void OnMouseDrag() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void OnMouseUp() {
        
    }

    private void OnMouseEnter() {
        mouseUp = true;
    }

    private void OnMouseExit() {
        mouseUp = false;
    }
}
