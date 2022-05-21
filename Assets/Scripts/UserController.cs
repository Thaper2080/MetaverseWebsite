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
    public float minZoom = 0;
    float zoomPosition;
    TextMeshProUGUI text;
    Color col;
    [SerializeField] GameObject MainCanvas;
    bool isreached;
    [SerializeField] GameObject welcome;
    [SerializeField] GameObject virtualStore;
    [SerializeField] GameObject socialLounge;
    [SerializeField] GameObject virtualMuseum;
    void Start()
    {
        text = GameObject.Find("aiverse").GetComponent<TextMeshProUGUI>();
        col = text.color;

    }
    void Update()
    {
        zoomLevel += Input.mouseScrollDelta.y * sensitivity;
        if (!isreached)
        {
            zoomLevel = Mathf.Clamp(zoomLevel, minZoom, maxZoom);
        }
        else
        {
            zoomLevel = Mathf.Clamp(zoomLevel, maxZoom, maxZoom);

        }
        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, speed * Time.deltaTime);
        if (col.a > 0)
        {
            float ratio = col.a - zoomLevel * .003f;
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
        DistanceReached();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide Sucess");
        zoomLevel = Mathf.Lerp(107,0, Time.deltaTime*10);
        other.gameObject.SetActive(false);
        MainCanvas.SetActive(true);
        isreached = true;
    }
    public void isFlareLit()
    {
        isreached = false;
        Camera.main.backgroundColor = Color.white;
        maxZoom = 250;
        minZoom = 85;

    }
    void DistanceReached()
    {
        if(zoomLevel>=130)
        {
            virtualStore.SetActive(true);
            welcome.SetActive(false);
        }
        if(zoomLevel >= 180)
        {
            socialLounge.SetActive(true);
        }
        if(zoomLevel >= 230)
        {
            virtualMuseum.SetActive(true);
        }
    }
}