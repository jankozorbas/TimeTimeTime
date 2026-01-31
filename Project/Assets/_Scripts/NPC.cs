using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    [SerializeField] private float minTimeToCount = 10f;
    [SerializeField] private float maxTimeToCount = 15f;

    private float timeToCount;
    private float checkTimeCounter;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        checkTimeCounter = ChooseRandomTime();
        StartCoroutine(CheckTimeRoutine());
    }

    private void Update()
    {
        checkTimeCounter -= Time.deltaTime;
    }

    private IEnumerator CheckTimeRoutine()
    {
        while (true)
        {
            if (checkTimeCounter <= 0f)
            {
                animator.SetBool("shouldCheckTime", true);
            }

            yield return new WaitForSeconds(5.2f);

            animator.SetBool("shouldCheckTime", false);
            checkTimeCounter = ChooseRandomTime();
        }
    }

    private float ChooseRandomTime()
    {
        timeToCount = Random.Range(minTimeToCount, maxTimeToCount);

        return timeToCount;
    }
}