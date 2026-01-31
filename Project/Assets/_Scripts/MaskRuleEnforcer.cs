using UnityEngine;

public class MaskRuleEnforcer : MonoBehaviour
{
    private void Start()
    {
        TimeManager.Instance.OnAfterMidnight += EnforceRule;
    }

    private void EnforceRule()
    {
        if (!TimeRules.PlayerIsWearingMask)
        {
            HandleUnmaskedPlayer();
        }
    }

    private void HandleUnmaskedPlayer()
    {
        Debug.Log("Player ignored the rule.");

        // Option A: Instant fail
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Option B: Fade + soft death
        // Option C: Disorientation effect
    }

    private void OnDisable()
    {
        TimeManager.Instance.OnAfterMidnight -= EnforceRule;
    }
}
