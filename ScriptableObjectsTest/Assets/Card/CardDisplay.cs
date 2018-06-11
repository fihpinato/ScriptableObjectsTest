using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public Vector3 maxSize;
    public Vector3 minSize;
    public float timeToTransform;

    public LayerMask layerMask;

    public TMP_Text cardNameText;

    Vector3 firstPos;

    GameObject player;
    Animator playerAnim;
    bool mouseUp = false;

    RaycastHit2D hit;

    void Start() {
        cardNameText.text = card.effect.ToString();

        firstPos = transform.position;
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
        if(Physics2D.Raycast(transform.position, transform.forward, layerMask)) {
            print("test");
            
            mouseUp = false;
        } else {
            transform.position = firstPos;
        }
    }

    private void OnMouseEnter() {
        mouseUp = true;
    }

    private void OnMouseExit() {
        mouseUp = false;
    }
}
