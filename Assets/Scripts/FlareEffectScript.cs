using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareEffectScript : MonoBehaviour
{
    public float speed;
    LensFlare flare;
    // Start is called before the first frame update
    void Start()
    {
        flare = GetComponent<LensFlare>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += Input.mouseScrollDelta.y;
        speed = Mathf.Clamp(speed, -40, 40);
        flare.brightness += speed*Time.deltaTime;
        flare.brightness = Mathf.Clamp(flare.brightness, 0, 180);


    }
}
