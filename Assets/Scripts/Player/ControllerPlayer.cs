using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] private Button moveButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button deletePointButton;
    [SerializeField] private PlayerMovement playerMovement;

    void Start()
    {
        moveButton.onClick.AddListener(OnMoveButtonClicked);
        restartButton.onClick.AddListener(OnRespawnButtonClicked);
        deletePointButton.onClick.AddListener(RemoveFlag);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
     private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
      private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       playerMovement.lastReachedTarget = new Vector3(-8, 0, 0); 
    }
    private void OnMoveButtonClicked()
    {
        playerMovement.StartMoving();
    }

    private void OnRespawnButtonClicked()
    {
        playerMovement.RespawnToLastTarget();
    }

    private void RemoveFlag()
    {
        playerMovement.RemoveLastPointInQueue();
    }
}
