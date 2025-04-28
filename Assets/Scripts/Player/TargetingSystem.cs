using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    public Transform currentTarget;

    public static TargetingSystem Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Check if it's the same target
                if (hit.collider.transform == currentTarget)
                {
                    // Deselect
                    /*
                    currentTarget = null;
                    Debug.Log("Target cleared");
                    */
                }
                else if (hit.collider.CompareTag("Enemy"))
                {
                    // Select new target
                    if (currentTarget != null && currentTarget.TryGetComponent<Enemy>(out var oldEnemy))
                    {
                        oldEnemy.SetSelected(false);
                    }

                    currentTarget = hit.collider.transform;

                    if (currentTarget.TryGetComponent<Enemy>(out var newEnemy))
                    {
                        newEnemy.SetSelected(true);
                    }

                    Debug.Log("Target acquired: " + currentTarget.name);
                }
                else
                {
                    // Clicked something else — also clear target
                    if (currentTarget != null && currentTarget.TryGetComponent<Enemy>(out var oldEnemy))
                    {
                        oldEnemy.SetSelected(false);
                    }
                    currentTarget = null;
                    Debug.Log("Target cleared (clicked non-enemy)");
                }
            }
        }
    }
}
