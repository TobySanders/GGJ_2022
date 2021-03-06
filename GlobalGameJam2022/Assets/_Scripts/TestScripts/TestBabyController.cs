using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBabyController : MonoBehaviour
{
    public GameObject _baby;
    public float movementSpeed = 1;

    private void Update()
    {
            var movement = Input.GetAxis("Horizontal");

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
    }
}
