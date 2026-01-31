using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public enum TimeState
    {
        BeforeMidnight,
        Midnight,
        AfterMidnight
    }

    [Header("Time Settings")]
    [SerializeField] private float timeUntilMidnight = 300f;
    [SerializeField] private float midnightDuration = 10f;

    public TimeState currentState { get; private set; }

    public event Action OnBeforeMidnight;
    public event Action OnMidnight;
    public event Action OnAfterMidnight;

    private float timer;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentState = TimeState.BeforeMidnight;
        timer = timeUntilMidnight;
        OnBeforeMidnight?.Invoke();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (currentState == TimeState.BeforeMidnight && timer <= 0f)
        {
            TriggerMidnight();
        }
        else if (currentState == TimeState.Midnight && timer <= 0f)
        {
            TriggerAfterMidnight();
        }
    }

    private void TriggerMidnight()
    {
        currentState = TimeState.Midnight;
        timer = midnightDuration;
        OnMidnight?.Invoke();
    }

    private void TriggerAfterMidnight()
    {
        currentState = TimeState.AfterMidnight;
        OnAfterMidnight?.Invoke();
    }
}