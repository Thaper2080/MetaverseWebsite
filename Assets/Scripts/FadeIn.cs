using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeIn : MonoBehaviour
{
    [SerializeField] RawImage image;
    Color col;
    float fadeRate = .005f;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        col = image.color;
        fadeRate = Mathf.Clamp(fadeRate, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (col.a < 1)
        {
            float ratio = col.a + fadeRate;
            col.a = Mathf.Lerp(0,1 , ratio);
            image.color = col;
        }
    }
}
