using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.up, 5 * Time.deltaTime);
    }
}