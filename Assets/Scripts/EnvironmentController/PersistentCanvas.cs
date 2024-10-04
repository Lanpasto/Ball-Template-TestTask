using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType<PersistentCanvas>().Length > 1)
        {
            Destroy(gameObject); 
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
