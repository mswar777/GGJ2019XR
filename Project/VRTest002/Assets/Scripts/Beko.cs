using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beko : MonoBehaviour
{
    float t;
    float life_time = 60.0f;
    BekoManager beko_manager;
    Vector2 theta;
    float movement_scale = 100.0f;
    float speed;
    float vt;
    float voice_time = 1f;
    Vector3 base_position;
    Vector3 direction;
    public AudioClip moving_voice;
    public AudioClip throw_voice;
    AudioSource audio_source;

    public bool release_flg = false;

    void Awake()
    {
        t = 0f;
        beko_manager = GameObject.Find("BekoManager").GetComponent<BekoManager>();
        theta = Vector2.zero;
        speed = Random.Range(2f, 6.0f);
        voice_time = speed * 0.01f;
        vt = Random.Range(0f, speed * 0.1f);
        audio_source = this.GetComponent<AudioSource>();
        audio_source.pitch = Random.Range(0.5f, 2f);
        movement_scale = Random.Range(movement_scale * 0.7f, movement_scale * 0.8f);
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
        //position.y = position.y;
        position.z = -Mathf.Sin(psit) * position.x + Mathf.Cos(psit) * position.z;
        this.transform.position = base_position + position;
        this.transform.forward = -(position - previous_position);
        t += Time.deltaTime;
        if (t >= speed)
            t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        vt += Time.deltaTime;
        life_time -= Time.deltaTime;
        if (life_time <= 0f)
            beko_manager.RemoveBeko(this.gameObject);
        if (!release_flg)
        {
            Moving();
            audio_source.clip = moving_voice;
        }
        else
        {
            audio_source.clip = throw_voice;
        }
        if (vt > voice_time)
        {
            audio_source.Play();
            vt = 0f;
        }
    }

}
