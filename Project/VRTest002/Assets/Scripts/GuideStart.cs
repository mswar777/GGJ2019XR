using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideStart : MonoBehaviour
{
    [SerializeField]
    private const float blink_interval = 0.8f;
    private float time_counter;
    [SerializeField]
    private Text text;

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
            text.enabled = !text.enabled;
        }
    }
}
