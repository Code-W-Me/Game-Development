using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
    [SerializeField]
    private float steerSpeed = 180f;
    [SerializeField]
    private float moveSpeed = 12f;
    [SerializeField]
    float slowSpeed = 14f;
    [SerializeField]
    float boostSpeed = 26f;
    

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("you are boosting");
            moveSpeed = boostSpeed;
        }     
    }
}
