using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager> {
    public const int MAP_WIDTH = 9;
    public const int MAP_HIGHT = 15;
    public const float SACLE = 0.63f;
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
    private Dictionary<MAPTYPE, MapModel> dicModel;

    void Awake()
    {
        this.dicModel = new Dictionary<MAPTYPE, MapModel>();
        this.maps = new Dictionary<int, Dictionary<int, Map>>();
        foreach(MapModel map in this.models)
        {
            this.dicModel.Add(map.type, map);
        }
        StartCoroutine(CreateMap());
    }
    MAPTYPE TypeByColRow(int row, int col)
    {
        if(row == 0)
        {
            if(col == 0)
            {
                return MAPTYPE.B_DOWN_LEFT;
            }
            if (col == MAP_WIDTH - 1)
            {
                return MAPTYPE.B_DOWN_RIGHT;
            }
            else
                return MAPTYPE.B_DOWN;
        }
        if(row == MAP_HIGHT - 1)
        {
            if (col == 0)
            {
                return MAPTYPE.B_TOP_LEFT;
            }
            if (col == MAP_WIDTH - 1)
            {
                return MAPTYPE.B_TOP_RIGHT;
            }
            else
                return MAPTYPE.B_TOP;
        }
        else
        {
            if (col == 0)
            {
                return MAPTYPE.B_LEFT;
            }
            if (col == MAP_WIDTH - 1)
            {
                return MAPTYPE.B_RIGHT;
            }
        }
        return MAPTYPE.NONE;
    }
    //khoi tao map ban dau
    [ContextMenu("create")]
    void test()
    {
        StartCoroutine(CreateMap());
    }
    public IEnumerator CreateMap()
    {
        for(int row = 0; row < MAP_HIGHT; row ++)
        {
            Dictionary<int, Map> mapCol = new Dictionary<int, Map>();
            for(int col = 0; col <MAP_WIDTH; col++)
            {

                //int index = Random.Range(0, 4);//random map type
                MAPTYPE type = TypeByColRow(row, col);


                Map map = this.CreatMapItem(row, col, type);
                if (map != null && !mapCol.ContainsKey(col))
                {
                    mapCol.Add(col, map);
                }
            }
            if(!this.maps.ContainsKey(row))
            {
                this.maps.Add(row, mapCol);
            }
        }
        yield return new WaitForEndOfFrame();
        //CreateBlook();
        yield return new WaitForEndOfFrame();
        CreateBorder();
    }
    public Map CreatMapItem(int row, int col, MAPTYPE type)
    {
        if (this.dicModel.ContainsKey(type))
        {
            MapModel model = this.dicModel[type];

            MapItem item = Instantiate(model.item) as MapItem;
            item.gameObject.SetActive(true);
            item.transform.SetParent(this.transform);
            item.transform.localScale = new Vector3(2, 2, 2);
            float down = MAP_HIGHT / 2 * SACLE;
            float left = MAP_WIDTH / 2 * SACLE;
            float x = col * SACLE - left;
            float y = row * SACLE - down;
            item.transform.localPosition = new Vector3(x, y);
            if (item != null)
            {
                item.Parse(col, row, type);
                Map map = new Map(row, col, item);
                return map;
            }
        }
        return null;
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
    
    public void CreateBlook()
    {
        for(int i = 0; i< 10; i++)
        {
            int row = Random.Range(1, MAP_HIGHT - 1);
            int col = Random.Range(1, MAP_WIDTH - 1);
            int type = Random.Range(1, 4);
            this.CreatMapItem(row, col, (MAPTYPE)type);
        }
    }
    public void CreateBorder()
    {
        //tao border lef-right
        for (int i = 0; i < MAP_HIGHT; i++)
        {
            Map left = this.CreatMapItem(i, -1, MAPTYPE.BORDER);
            Map right = this.CreatMapItem(i, MAP_WIDTH, MAPTYPE.BORDER);
        }

        //tao border top-down
        for (int i = 0; i < MAP_WIDTH; i++)
        {
            Map down = this.CreatMapItem(-1, i, MAPTYPE.BORDER);
            Map top = this.CreatMapItem(MAP_HIGHT, i, MAPTYPE.BORDER);
        }
    }
}
