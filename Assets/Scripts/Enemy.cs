using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; 

    public int hitPoints = 3;
    private Transform target; 


    void Update()
    {
        if (target == null) return;
        Vector3 direction = (target.position - transform.position).normalized; 
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target.position);
    }

    public void SetTarget(GameObject targetObject)
    {
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitPoints--; 

            if (hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
