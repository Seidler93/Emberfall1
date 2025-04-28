using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public float damage = 10f;

    private NavMeshAgent agent;
    private float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackRange)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.ResetPath();

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                if (target.TryGetComponent<PlayerHealth>(out var player))
                {
                    player.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    public void SetTarget(Transform player)
    {
        if (target == null)
        {
            target = player;
            Debug.Log("Target set from child trigger");
        }
    }


    private bool HasLineOfSight(Transform player)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (Physics.Raycast(transform.position + Vector3.up, direction, out RaycastHit hit, distance))
        {
            return hit.transform == player;
        }

        return false;
    }
}
