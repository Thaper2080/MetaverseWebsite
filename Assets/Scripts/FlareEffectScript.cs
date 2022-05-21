using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareEffectScript : MonoBehaviour
{
    public float speed;
    LensFlare flare;
    public bool isLit;
    UserController user;
    // Start is called before the first frame update
    void Start()
    {
        flare = GetComponent<LensFlare>();
        user = GameObject.Find("Main Camera").GetComponent<UserController>();

        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Input.mouseScrollDelta.y;
        speed = Mathf.Clamp(speed, -40, 40);
        flare.brightness += speed*Time.deltaTime;
        flare.brightness = Mathf.Clamp(flare.brightness, 0, 180);
        if(flare.brightness >= 180)
        {
            isLit = true;
            user.isFlareLit();
        }

    }
}
