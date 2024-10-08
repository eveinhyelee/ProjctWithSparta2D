using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");   
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector2 direction = new Vector2(horizontal, vertical);
        // ���̸� 1�� ����� �۾�
        direction.Normalize();

        rb.velocity = direction * speed;
    }
}
