using System.Collections;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    private Coroutine winCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winCoroutine = StartCoroutine(WinAfterDelay());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && winCoroutine != null)
        {
            StopCoroutine(winCoroutine);
        }
    }

    private IEnumerator WinAfterDelay()
    {
        AudioManager.Instance.PlaySFX("nextLevel");
        yield return new WaitForSeconds(1f);
        GameManager.Instance.NextLevel();
    }
}
