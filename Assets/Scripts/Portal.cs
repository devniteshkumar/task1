using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform linkedPortal; // The other portal
    private Collider2D portalCollider; // Portal's own collider
    private bool isTeleporting = false; // Prevents immediate re-entry

    private void Start()
    {
        portalCollider = GetComponent<Collider2D>(); // Get portal collider
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            StartCoroutine(Teleport(other.transform));
        }
    }

    private IEnumerator Teleport(Transform player)
    {
        isTeleporting = true; // Prevents instant re-entry

        // Get player's Rigidbody2D
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Vector2 velocity = rb.velocity; // Store velocity before teleport

        // Disable both portals' colliders temporarily
        portalCollider.enabled = false;
        linkedPortal.GetComponent<Collider2D>().enabled = false;

        // Move player to linked portal
        player.position = linkedPortal.position;

        // Restore velocity
        rb.velocity = velocity;

        // Wait to prevent instant re-entry
        yield return new WaitForSeconds(0.1f);

        // Re-enable both portal colliders
        portalCollider.enabled = true;
        linkedPortal.GetComponent<Collider2D>().enabled = true;

        isTeleporting = false;
    }
}
