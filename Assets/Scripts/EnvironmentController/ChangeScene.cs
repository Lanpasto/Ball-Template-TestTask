using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int level;
    public void PutDownButtonChangeScene()
    {
        SceneManager.LoadSceneAsync(level);
    }
}
