using UnityEngine;
using TMPro;

public class AtTouchMessage : MonoBehaviour
{
    private NewPlayer playerInput;
    private TextMeshProUGUI text;
    private Animator anim;
    float animTimer = 0f;
    private Transform child;
    [SerializeField] private float offset;
    [SerializeField] private float zOffset;

    private void Awake()
    {
        playerInput = new NewPlayer();
    }

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        anim = GetComponentInChildren<Animator>();

        child = transform.GetChild(0);
        child.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 touchPoint = playerInput.MainAction.TouchPoint.ReadValue<Vector2>();
        touchPoint = new Vector2(touchPoint.x, touchPoint.y + offset);
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform.parent.transform, touchPoint, Camera.main, out localPoint);
        gameObject.transform.localPosition = new Vector3(localPoint.x, localPoint.y, zOffset);

        if (animTimer > 0f)
        {
            animTimer -= Time.deltaTime;
        }
        else if (animTimer < 0f) child.gameObject.SetActive(false);
    }

    public void TextPop(string input)
    {
        child.gameObject.SetActive(true);
        text.text = input;
        animTimer = 0.25f;
        anim.SetTrigger("Active");
    }
}
