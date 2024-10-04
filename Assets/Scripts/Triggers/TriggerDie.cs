using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.GameOver();
        AudioManager.Instance.PlaySFX("trap");
    }
}
