using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float speed;
    [SerializeField] private GameObject flagPrefab;
    [SerializeField] private Slider speedSlider;
    private Dictionary<Vector3, int> clickPoints = new Dictionary<Vector3, int>();
    private Queue<Vector3> targetsQueue = new Queue<Vector3>();
    private Rigidbody2D rb;
    public Vector3 currentTarget { get; set; }
    public Vector3 lastReachedTarget { get; set; }
    private bool isMoving = false;

    private FlagManager flagManager;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        flagManager = new FlagManager(flagPrefab);

        // Ініціалізація слайдера
        if (speedSlider != null)
        {
            speedSlider.onValueChanged.AddListener(SetSpeed);
        }
    }

    void Update()
    {
        if (!isMoving && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Перевіряємо, чи дотик не на UI
            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                AddClickPosition();
            }
        }
        if (targetsQueue.Count > 0)
        {
            currentTarget = targetsQueue.Dequeue();
            isMoving = true;
        }

    }

    void FixedUpdate()
    {
        if (isMoving) MoveToTarget(currentTarget);
        Debug.Log("Fixed" + currentTarget);

    }

    private void AddClickPosition()
    {
        Vector3 clickPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        clickPosition.z = 0;

        if (!clickPoints.ContainsKey(clickPosition))
        {
            clickPoints.Add(clickPosition, 1);
            targetsQueue.Enqueue(clickPosition);
            flagManager.PutFlag(clickPosition);
        }
    }

    private void MoveToTarget(Vector3 target)
    {
        Vector2 direction = ((Vector2)target - rb.position).normalized;
        rb.AddForce(direction * speed);
        if (Vector2.Distance(rb.position, target) <= 0.1f)
        {
            rb.velocity = Vector2.zero;
            isMoving = false;
            lastReachedTarget = target;
            StartCoroutine(RemoveFlagAfterReachedTarget(target));
        }
    }

    private IEnumerator RemoveFlagAfterReachedTarget(Vector3 target)
    {
        while (Vector3.Distance(rb.position, target) > 0.1f)
        {
            yield return null;
        }

        if (Vector3.Distance(rb.position, target) <= 0.1f)
        {
            flagManager.RemoveFlagsAtTarget(target);
        }
    }



    public void RespawnToLastTarget()
    {
        if (lastReachedTarget != Vector3.zero)
        {
            rb.position = lastReachedTarget;
            rb.velocity = Vector2.zero;
            clickPoints.Clear();
            targetsQueue.Clear();
            flagManager.RemoveAllFlags();
            isMoving = false;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void StartMoving()
    {
        if (targetsQueue.Count > 0)
        {
            currentTarget = targetsQueue.Dequeue();
            isMoving = true;
        }
    }

    public void RemoveLastPointInQueue()
    {
        if (targetsQueue.Count > 0)
        {
            List<Vector3> tempList = new List<Vector3>(targetsQueue);
            Vector3 lastTarget = tempList[tempList.Count - 1];
            Debug.Log("Attempting to remove flag at: " + lastTarget);
            tempList.RemoveAt(tempList.Count - 1);
            targetsQueue = new Queue<Vector3>(tempList);
            flagManager.RemoveFlagsAtTarget(lastTarget);
            clickPoints.Remove(lastTarget);
        }
        else
        {
            Debug.Log("No more targets in queue to remove.");
        }
    }


}
