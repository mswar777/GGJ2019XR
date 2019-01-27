using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    [SerializeField]
    private int beko_counter = 1;

    TestSceneLoader loader;

    // Start is called before the first frame update
    void Start()
    {
        loader = GameObject.Find("SceneLoader").GetComponent<TestSceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        //if (collision.gameObject.Name != "CawBall")
        //     return;

        if (collision.relativeVelocity.magnitude > 1)
        {
            Debug.Log("caw hit!");
            if (--beko_counter <= 0)
            {
                if (loader != null)
                    loader.NextSceneLoad();
                //audioSource.Play();
            }
        }
    }
}
