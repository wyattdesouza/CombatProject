using UnityEngine;

public class TracerRound : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private Vector3? target;
    
    public void LoadTarget(Vector3 newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)target, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, (Vector3)target) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}