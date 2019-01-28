using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShotBeko : MonoBehaviour
{
    public int ColliderOffTime = 1;
    private Collider col;
    // Start is called before the first frame update
    async void Awake()
    {
        col = gameObject.GetComponent<Collider>();
        col.enabled = false;
        await Task.Delay(ColliderOffTime * 100);
        col.enabled = true;
    }

    private float life_time;

    // Start is called before the first frame update
    void Start()
    {
        life_time = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        life_time -= Time.deltaTime;
        if (life_time <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
