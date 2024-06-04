using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tank : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        float moveVertical = 0;
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            moveVertical = speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        moveVertical *= Time.deltaTime;
        moveHorizontal *= Time.deltaTime;

        transform.Translate(moveHorizontal, 0, moveVertical);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
