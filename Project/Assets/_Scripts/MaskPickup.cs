using UnityEngine;

public class MaskPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        TimeRules.PlayerHasMask = true;
        TimeRules.PlayerIsWearingMask = true;
        gameObject.SetActive(false);
    }
}