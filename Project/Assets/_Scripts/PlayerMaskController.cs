using UnityEngine;

public class PlayerMaskController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private KeyCode toggleMaskKey = KeyCode.M;

    [Header("References")]
    [SerializeField] private GameObject mask;

    private void Update()
    {
        if (!TimeRules.PlayerHasMask)
            return;

        if (Input.GetKeyDown(toggleMaskKey))
        {
            ToggleMask();
        }

        if (TimeRules.PlayerIsWearingMask)
            Debug.Log("Player is wearing a mask.");
        else
            Debug.Log("Player is NOT wearing a mask.");
    }

    private void ToggleMask()
    {
        TimeRules.PlayerIsWearingMask = !TimeRules.PlayerIsWearingMask;

        if (mask != null)
            mask.SetActive(TimeRules.PlayerIsWearingMask);
    }
}
