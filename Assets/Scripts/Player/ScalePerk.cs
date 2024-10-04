using UnityEngine;

public class ScalePerk : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("coin");
            other.transform.localScale *= 0.5f;
            Destroy(gameObject);
        }
    }
}
