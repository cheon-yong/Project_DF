using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();

    public float Speed { get; set; }

    public float percentage = 60.0f;
    private void CreateObject()
    {
        if (Random.Range(0, 100) < percentage)
        {
            GameObject go = Managers.Resource.Instantiate("Object/MapObject", Managers.Map.currentMap.transform);
            go.transform.localPosition = new Vector3(20.5f, -3f, -1f);
            go.GetComponent<MapObject>().SetSpeed(Speed + Random.Range(0, Speed));
        }
    }
}
