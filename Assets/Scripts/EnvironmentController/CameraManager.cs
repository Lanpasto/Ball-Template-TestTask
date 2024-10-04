using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public GameObject player; 
    private CinemachineVirtualCamera virtualCamera;

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
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        
        if (virtualCamera != null && player != null)
        {
            virtualCamera.Follow = player.transform;
        }
    }
}
