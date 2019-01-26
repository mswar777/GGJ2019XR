using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beko : MonoBehaviour
{
    float t;
    float life_time = 5.0f;
    BekoManager beko_manager;
    Vector2 theta;
    float movement_scale = 1.0f;
    float speed;
    Vector3 base_position;
    Vector3 direction;

    public bool release_flg = false;

    void Awake()
    {
        t = 0f;
        beko_manager = GameObject.Find("BekoManager").GetComponent<BekoManager>();
        theta = Vector2.zero;
        speed = Random.Range(8.0f, 16.0f);
        movement_scale = Random.Range(0.1f, 0.5f);
        base_position = Vector3.zero;
        direction = this.transform.up * movement_scale;
        this.transform.position = direction;
    }

    public void Initialize(Vector3 BasePosition, Vector3 Direction)
    {
        base_position = BasePosition;
        direction = Direction * movement_scale / Direction.magnitude;
        this.transform.position = direction + base_position;
    }

    public void GiveGrass(float life_value = 1.0f)
    {
        life_time += life_value;
        if (life_time >= 10f)
        {
            beko_manager.AddBeko();
            life_time = 5f;
        }
    }

    void Moving()
    {
        float omega = 2f * Mathf.PI * (t / speed);
        float phit = omega + theta.x;
        float psit = omega + theta.y;
        Vector3 previous_position = this.transform.position - base_position;
        Vector3 position;
        position.x = Mathf.Cos(phit) * direction.x - Mathf.Sin(phit) * direction.y;
        position.y = Mathf.Sin(phit) * direction.x + Mathf.Cos(phit) * direction.y;
        position.z = direction.z;
        position.x = Mathf.Cos(psit) * position.x + Mathf.Sin(psit) * position.z;
        position.y = position.y;
        position.z = -Mathf.Sin(psit) * position.x + Mathf.Cos(psit) * position.z;
        this.transform.position = base_position + position;
        this.transform.forward = position - previous_position;
        t += Time.deltaTime;
        if (t >= speed)
            t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
//        life_time -= Time.deltaTime;
        if (life_time <= 0f)
            beko_manager.RemoveBeko(this.gameObject);
        if (!release_flg)
        {
            Moving();
        }
    }

}
