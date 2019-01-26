using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BekoManager : MonoBehaviour
{
    int beko_maxnumer = 50;
    public int beko_number = 15;
    float field_scale = 1f;
    List<GameObject> bekos;
    GameObject beko_prefab;

    void InstantiateBeko()
    {
        bekos.Add(Instantiate(beko_prefab, transform.position, Quaternion.identity));

        var pos = Vector3.zero; //new Vector3(Random.Range(-field_scale, field_scale), Random.Range(-field_scale, field_scale), 0f);
        var dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        bekos[bekos.Count - 1].GetComponent<Beko>().Initialize(pos, dir);
    }

    void Start()
    {
        bekos = new List<GameObject>();
        beko_prefab = (GameObject)Resources.Load("Prefabs/Beko");
        for (int n = 0; n < beko_number; n++)
            InstantiateBeko();
    }

    public void AddBeko()
    {
        if (bekos.Count < beko_maxnumer)
            InstantiateBeko();
    }

    public void RemoveBeko(GameObject GOBJ)
    {
        Destroy(GOBJ);
        bekos.RemoveAt(bekos.IndexOf(GOBJ));
    }

    public void GiveGrassToRandomBeko()
    {
        int n = Random.Range(0, bekos.Count);
        bekos[n].GetComponent<Beko>().GiveGrass();
    }

    // Update is called once per frame
    void Update()
    {
        field_scale = Mathf.Sqrt((float)beko_number + 1f) * 100f;
    }
}
