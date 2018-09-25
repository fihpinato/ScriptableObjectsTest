using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class CardDisplay : NetworkBehaviour {

    public Card card;

    public Vector3 maxSize;
    public Vector3 minSize;
    public float timeToTransform;

    public LayerMask layerMask;

    public TMP_Text jokenpoText;
    public TMP_Text nameText;
    public TMP_Text delayText;
    public TMP_Text delayOnHitText;
    public TMP_Text delayOnBlockText;
    public TMP_Text damageText;

    GameObject player;
    Animator playerAnim;
    bool mouseUp = false;
    Vector3 firstPos;
    Camera cam;

    RaycastHit hit;
    Ray ray;

    void Start() {
		if(isServer){
	        jokenpoText.text = card.jokenpo.ToString();
	        nameText.text = card.name;
	        delayText.text = card.delay.ToString();
	        delayOnHitText.text = card.delayOnHit.ToString();
	        delayOnBlockText.text = card.delayOnBlock.ToString();
	        damageText.text = card.damage.ToString();
	        firstPos = transform.position;
	        cam = Camera.main;
		}
    }

    private void Update() {
        TransformCardSize();
    }

    void TransformCardSize() {
        Vector3 newSize;
        if (mouseUp) {
            newSize = maxSize;
        } else {
            newSize = minSize;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, newSize, Time.deltaTime * 5f);
    }

    private void OnMouseDown() {

    }

    private void OnMouseDrag() {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        transform.position = mousePos;
    }

    private void OnMouseUp() {
        if (Physics.Raycast(transform.position, transform.forward * 10f, out hit)) {
            if (hit.collider.CompareTag("Respawn")) {
                mouseUp = false;
                transform.position = hit.collider.transform.position;
                GameAreaScript area = hit.collider.GetComponent<GameAreaScript>();
                area.hasCard = true;
                TurnManager.Instance.GetOutCardOfList(transform);
            }
        } else {
            //TurnManager.Instance.AddCardInList(transform);
            //transform.position = firstPos;
        }
    }

    private void OnMouseEnter() {
        mouseUp = true;
    }

    private void OnMouseExit() {
        mouseUp = false;
    }
}
