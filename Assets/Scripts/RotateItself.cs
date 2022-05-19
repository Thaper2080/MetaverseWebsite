using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItself : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAroundLocal(Vector3.up, speed * Time.deltaTime);
    }
}
