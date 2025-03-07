using UnityEngine;
using Cinemachine;
using System.Collections;

public class BossRoomTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera bossRoomCamera;
    public GameObject bossRoomBarrier; // Assign this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCamera.Priority = 0;  // Deactivate player camera
            bossRoomCamera.Priority = 10; // Activate boss room camera

            StartCoroutine(EnableBarrierAfterDelay());
        }
    }

    private IEnumerator EnableBarrierAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Wait 1 second
        bossRoomBarrier.SetActive(true); // Enable the barrier
    }
}
