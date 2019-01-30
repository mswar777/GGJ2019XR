using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideStart : MonoBehaviour
{
    const float blink_interval = 0.6f;
    float time_counter;

    // Start is called before the first frame update
    void Start()
    {
        time_counter = blink_interval;
        //StartCouroutin();
    }

    // Update is called once per frame
    void Update()
    {
        time_counter -= Time.deltaTime;
        if (time_counter <= 0.0f)
        {
            time_counter = blink_interval;
            // on/off toggle
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
