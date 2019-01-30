using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShotBeko : MonoBehaviour
{
    [SerializeField]
    private int ColliderOffTime = 1;
    [SerializeField]
    private int LifeTime = 20;

    private Collider col;
    // Start is called before the first frame update
    async void Awake()
    {
        col = gameObject.GetComponent<Collider>();
        col.enabled = false;
        await Task.Delay(ColliderOffTime * 100);
        col.enabled = true;
    }

    private float life_time_counter;

    // Start is called before the first frame update
    void Start()
    {
        life_time_counter = LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        life_time_counter -= Time.deltaTime;
        if (life_time_counter <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
