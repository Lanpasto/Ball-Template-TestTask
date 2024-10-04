using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TeleportAfterDelay(collision));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines(); 
    }

    private IEnumerator TeleportAfterDelay(Collider2D collision)
    {
        float waitTime = 2f;
        float timer = 0f;

        while (timer < waitTime)
        {
            timer += Time.deltaTime; 
            yield return null; 
        }

        if (collision != null)
        {
            collision.transform.position = teleportTarget.position; 
            Debug.Log($"{collision.gameObject.name} teleported to {teleportTarget.position}");
        }
    }
}
