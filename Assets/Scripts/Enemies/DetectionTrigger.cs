using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
    private EnemyAI enemyAi;

    private void Awake()
    {
        enemyAi = GetComponentInParent<EnemyAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (enemyAi == null || enemyAi.target != null) return;

        if (other.CompareTag("Player"))
        {
            enemyAi.SetTarget(other.transform);
        }
    }
}
