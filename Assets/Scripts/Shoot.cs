using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float missileSpeed = 40.0f;
    float cooldownTime = 0.5f;
    float timeSinceLastShot = 0.0f;
    public GameObject missilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastShot > 0)
        {
            timeSinceLastShot -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && timeSinceLastShot <= 0)
        {
            Vector3 missilePosition = transform.position + transform.forward*3;
            GameObject missile = Instantiate(missilePrefab, missilePosition, transform.rotation);
            missile.GetComponent<Rigidbody>().velocity = transform.forward * missileSpeed;
            Destroy(missile, 4.0f);
            timeSinceLastShot = cooldownTime;
        }
    }
}
