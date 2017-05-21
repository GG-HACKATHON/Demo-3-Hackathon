using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager> {
    public const int MAP_WIDTH = 9;
    public const int MAP_HIGHT = 9;
    [System.Serializable]
    public class MapModel
    {
        public MAPTYPE type;
        public MapItem item;
    }
    [System.Serializable]
    public class Map
    {
        public int col;
        public int row;
        public MapItem item;
        public Map()
        {

        }
        public Map(int col, int row, MapItem item)
        {
            this.col = col;
            this.row = row;
            this.item = item;
        }
    }
    public List<MapModel> models;
    public Dictionary<int,Dictionary<int,Map>> maps;//row-ColMap
    public Map playerCurrent;//vi tri hien tai cua player tren map
    private Dictionary<MAPTYPE, MapModel> dicModel;

    void Awake()
    {
        this.dicModel = new Dictionary<MAPTYPE, MapModel>();
        this.maps = new Dictionary<int, Dictionary<int, Map>>();
    }
    //khoi tao map ban dau
    public void CreateMap()
    {
        for(int row = 0; row < MAP_HIGHT; row ++)
        {
            Dictionary<int, Map> mapCol = new Dictionary<int, Map>();
            for(int col = 0; col <MAP_WIDTH; col++)
            {
                int index = Random.Range(0, 4);//random map type
                Map map = new Map(row, col, null);
                if(!mapCol.ContainsKey(col))
                {
                    mapCol.Add(col, map);
                }
            }
            if(!this.maps.ContainsKey(row))
            {
                this.maps.Add(row, mapCol);
            }
        }
    }
    public Map GetMapItem(int row, int col)
    {
        if(this.maps.ContainsKey(row))
        {
            Dictionary<int, Map> mapRow = this.maps[row];
            if(mapRow.ContainsKey(col))
            {
                return this.maps[row][col];
            }
        }
        return null;
    }
    public Map PlayerPosition()
    {
        Player player = PlayerController.Instance.mainPlayer;
        BaseBody head = player.head;
        //kiem tra vi tri cua no tren ban do
        //tra ve ket qua la row, col, positon
        return null;
    }

}
