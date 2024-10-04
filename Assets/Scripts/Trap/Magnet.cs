using UnityEngine;

public class Magnet : MonoBehaviour
{
    [Header("Attraction Settings")]
    [SerializeField] private float attractionRadius; 
    [SerializeField] private float attractionForce;
    [SerializeField] private Color fillColor = new Color(0, 0, 1, 0.39f); 

    private void Update()
    {
        AttractObjects();
    }

    private void AttractObjects()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, attractionRadius);
        
        foreach (Collider2D obj in objectsInRange)
        {
            if (obj.CompareTag("Player") && obj.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                ApplyAttraction(rb);
            }
        }
    }

    private void ApplyAttraction(Rigidbody2D rb)
    {
        Vector2 direction = (transform.position - rb.transform.position).normalized;
        rb.AddForce(direction * attractionForce * Time.deltaTime);
    }
    //Draw in Editor only
    private void OnDrawGizmos()
    {
        Gizmos.color = fillColor; 
        Gizmos.DrawWireSphere(transform.position, attractionRadius); 
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
