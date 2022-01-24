using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    Dictionary<int, MapController> maps = new Dictionary<int, MapController>();
    public MapController CreateMap(int mapId)
    {
        string mapName = "Map_" + mapId.ToString("00");
        GameObject go = Managers.Resource.Instantiate($"Map/{mapName}", Managers.Scene.CurrentScene.transform);
        go.name = "Map";

        MapController mc = go.AddComponent<MapController>();
        maps.Add(mapId, mc);
        return mc;
    }

    public MapController FindById(int id)
    {
        MapController mc = null;
        maps.TryGetValue(id, out mc);
        return mc;
    }

    public void Remove(int mapId)
    {
        if (!maps.ContainsKey(mapId))
            return;

        maps.Remove(mapId);
    }
}
