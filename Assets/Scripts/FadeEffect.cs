using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI image;
    Color col;
    float fadeRate = .04f;
    [SerializeField] float fadeLimit;
    UserController user;
    // Start is called before the first frame update
    void Start()
    {
        user = GameObject.Find("Main Camera").GetComponent<UserController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (user.zoomLevel < fadeLimit)
        {
            float ratio = col.a + fadeRate;
            col.a = Mathf.Lerp(0, 1, ratio);
            image.color = col;
        }
        if (user.zoomLevel >= fadeLimit)
        {
                float link = col.a - fadeRate;
                col.a = Mathf.Lerp(0, 1, link);
                image.color = col;
        
        }

    }
}
