using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    Dictionary<int, GameObject> objects = new Dictionary<int, GameObject>();

    float speed;
    public float Speed 
    { 
        get { return speed; }
        set
        {
            speed = value;
            foreach (GameObject go in objects.Values)
            {
                go.GetComponent<MapObject>().SetSpeed(value);
            }
        }
    }
    int id = 0;

    public void CreateObject(float percentage)
    {
        if (Random.Range(0, 100) < percentage)
        {
            CreateObject(new Vector3(20.5f, -3f, -1f));
        }
    }

    public void CreateObject(Vector3 position)
    {
        GameObject go = Managers.Resource.Instantiate("Object/MapObject", Managers.Map.currentMap.transform);
        go.transform.localPosition = position;
        go.GetComponent<MapObject>().SetSpeed(Speed + Random.Range(0, Speed));
        objects.Add(id++, go);
    }

    public void RemoveObject(int id)
    {
        if (objects.ContainsKey(id) == false)
            return;

        GameObject go = FindById(id);
        if (go == null)
            return;

        objects.Remove(id);
        Managers.Resource.Destroy(go);
    }

    public GameObject FindById(int id)
    {
        GameObject go;
        objects.TryGetValue(id, out go);
        return go;
    }


    public void Clear()
    {
        foreach (GameObject go in objects.Values)
            Managers.Resource.Destroy(go);
        objects.Clear();
        id = 0;
        Speed = 0;
    }
}
