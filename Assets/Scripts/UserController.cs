using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserController : MonoBehaviour
{
    // Movement based Scroll Wheel Zoom.
    public Transform parentObject;
    public float zoomLevel;
    public float sensitivity = 1;
    public float speed = 30;
    public float maxZoom = 30;
    float zoomPosition;
    TextMeshProUGUI text;
    Color col;
    [SerializeField] GameObject MainCanvas;

    void Start()
    {
        text = GameObject.Find("aiverse").GetComponent<TextMeshProUGUI>();
        col = text.color;

    }
    void Update()
    {
        zoomLevel += Input.mouseScrollDelta.y * sensitivity;
        zoomLevel = Mathf.Clamp(zoomLevel, 0, maxZoom);
        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, speed * Time.deltaTime);
        if (col.a > 0)
        {
            float ratio = col.a - zoomLevel * .001f;
            col.a = Mathf.Lerp(0, 1, ratio);
            text.color = col;
            if(col.a <0.9f)
            {
                transform.position = Vector3.Lerp(transform.position, parentObject.transform.position, Time.deltaTime * 2);
            }
        }
        else
        {

            transform.position = parentObject.position + (transform.forward * zoomPosition);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide Sucess");
        other.gameObject.SetActive(false);
        MainCanvas.SetActive(true);
    }
}