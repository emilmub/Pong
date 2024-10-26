using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private string playerName = "P1";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis(playerName + " Vertical");
        transform.transform.position += verticalInput * Time.deltaTime * speed * Vector3.up;
    }
}
