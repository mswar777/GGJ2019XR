using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{

    BekoManager beko_manager;

    // Start is called before the first frame update
    void Start()
    {
        beko_manager = GameObject.Find("BekoManager").GetComponent<BekoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            beko_manager.GiveGrassToRandomBeko();
        }
    }
}
