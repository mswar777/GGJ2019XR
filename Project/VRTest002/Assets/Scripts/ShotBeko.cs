using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShotBeko : MonoBehaviour
{
    [SerializeField]
    private int LifeTime = 20;
    private float life_time_counter;

#if false
    [SerializeField]
    private int ColliderOffTime = 1;
    private Collider col;

    // Start is called before the first frame update
    async void Awake()
    {
        //生成時～発射後の短い間、コリジョンOFF
        col = gameObject.GetComponent<Collider>();
        col.enabled = false;
        await Task.Delay(ColliderOffTime * 100);
        col.enabled = true;
    }
#endif

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
