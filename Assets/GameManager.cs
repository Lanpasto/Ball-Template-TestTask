using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject winMenu;

    [Header("Game Settings")]
    public GameObject player;
    public int currentLevel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateLevelText();
    }

    private void Update()
    {
        UpdateLevelText();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    private void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    /* 
    * TheRestart Game funtction! 
    * Disable the GameOverGameOver 
    * Load the current level
    * Spawn the player at the starting position and set the target if the player dies while moving to the target
    * Change size player
    */
    public void RestartGame()
    {
        if (player != null)
        {
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                gameOverMenu.SetActive(false);
                SceneManager.LoadScene(currentLevel);
                player.transform.position = new Vector3(-8, 0, 0);
                player.transform.localScale = Vector3.one; 
                playerMovement.currentTarget = new Vector3(-8, 0, 0);
                Time.timeScale = 1f;
            }
            else
            {
                Debug.LogError("PlayerMovement component is missing on player.");
            }
        }
    }

    public void NextLevel()
    {
        currentLevel++;

        if (currentLevel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(currentLevel);
            player.transform.position = new Vector3(-8, 0, 0); // Set the player's position
        }
        else
        {
            Win();
        }
    }
    public void ExitApplication()
    {
        Application.Quit();
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
