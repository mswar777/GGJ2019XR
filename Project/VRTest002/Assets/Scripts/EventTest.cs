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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            beko_manager.GiveGrassToRandomBeko();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                Debug.Log("OK");
                if (hit.collider.gameObject.CompareTag("beko"))
                {
                    beko_manager.RemoveBeko(hit.collider.gameObject);
                }
            }
        }
    }
}
