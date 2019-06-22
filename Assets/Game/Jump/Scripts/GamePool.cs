using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PoolObject {
    public GameObject poolobject;
    public string gameTable;

    public PoolObject(GameObject g, string t) {
        poolobject = g;
        gameTable = t;
    }
}

public class GamePool : SingletonTemplate<GamePool> {

    private List<PoolObject> gameList = new List<PoolObject>();

    private Dictionary<string, GameObject> gamePrefabs = new Dictionary<string, GameObject>();

    /// <summary>
    /// 预加载指定数量的对象到对象池中
    /// </summary>
    /// <param name="poolObject">游戏对象</param>
    /// <param name="number">预加载数量</param>
    /// <param name="transform">父物体</param>
    /// /// <param name="table">游戏对象标签</param>
    /// <returns></returns>
    public bool PreloadingGameObject(GameObject poolObject , int number , string table, Transform transform = null) {
        if (number <= 0 || poolObject == null)
            return false;
        if (!gamePrefabs.ContainsKey(table)) {
            gamePrefabs.Add(table , poolObject);
        }

        for (int i = 0; i < number; i++) {
            GameObject go = Instantiate(poolObject , transform);
            go.SetActive(false);
            gameList.Add(new PoolObject(go , table));
        }
        
        return true;
    }
    /// <summary>
    /// 查询是否加载了指定标签的对象
    /// </summary>
    /// <param name="ObjectName"></param>
    /// <returns></returns>
    public bool SelectObject(string ObjectName) {
        return gamePrefabs.ContainsKey(ObjectName);
    }

    /// <summary>
    /// 获取场景中所有激活状态下的指定对象
    /// </summary>
    /// <param name="objectName"></param>
    /// <returns></returns>
    public List<GameObject> GetActiveObjectAll(string objectName) {
        List<GameObject> gameL = new List<GameObject>();
        gameList.ForEach(go => {
            if (go.gameTable.Equals(objectName) && go.poolobject.activeSelf) {
                gameL.Add(go.poolobject);
            }
        });
        return gameL;
    }

    /// <summary>
    /// 禁用指定table的所有对象
    /// </summary>
    /// <param name="table"></param>
    public void DisableObjectWitchTable(string table)
    {
        gameList.ForEach(go => {
            if (go.gameTable.Equals(table) && go.poolobject.activeSelf)
            {
                go.poolobject.SetActive(false);
            }
        });
    }

    /// <summary>
    /// 返回一个激活的对象到指定位置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="table"></param>
    /// <param name="postion"></param>
    /// <returns></returns>
    public T InstantiatePoolObject<T>(string table, Vector3 postion, Quaternion quaternion , Vector3 scale) {
        if (gamePrefabs.ContainsKey(table)) {
            foreach (PoolObject p in gameList) {
                if (p.gameTable.Equals(table) && !p.poolobject.activeSelf)
                {
                    p.poolobject.transform.position = postion;
                    p.poolobject.transform.rotation = quaternion;
                    if(scale.x != -100)
                        p.poolobject.transform.localScale = scale;
                    p.poolobject.SetActive(true);
                    return p.poolobject.GetComponent<T>();
                }
            }
            GameObject go = Instantiate(gamePrefabs[table]);
            go.SetActive(false);
            go.transform.position = postion;
            go.transform.rotation = quaternion;
            if (scale.x != -100)
                go.transform.localScale = scale;
            go.SetActive(true);
            gameList.Add(new PoolObject(go,table));
            return go.GetComponent<T>();
        }
        Debug.Log("<color=bule> 错误的从对象池实例化 </color>");
        return default(T);
    }

    public T InstantiatePoolObject<T>(string table, Vector3 postion, Quaternion quaternion)
    {
        if (gamePrefabs.ContainsKey(table))
        {
            foreach (PoolObject p in gameList)
            {
                if (p.gameTable.Equals(table) && !p.poolobject.activeSelf)
                {
                    p.poolobject.transform.position = postion;
                    p.poolobject.transform.rotation = quaternion;
                    p.poolobject.SetActive(true);
                    return p.poolobject.GetComponent<T>();
                }
            }
            GameObject go = Instantiate(gamePrefabs[table]);
            go.SetActive(false);
            go.transform.position = postion;
            go.transform.rotation = quaternion;
            go.SetActive(true);
            gameList.Add(new PoolObject(go, table));
            return go.GetComponent<T>();
        }
        Debug.Log("<color=bule> 错误的从对象池实例化 </color>");
        return default(T);
    }

    public GameObject InstantiatePoolObject(string table, Vector3 postion, Quaternion quaternion)
    {
        return InstantiatePoolObject<Transform>(table, postion, Quaternion.identity , new Vector3(-100,-100,-100)).gameObject;
    }

    public GameObject InstantiatePoolObject(string table, Vector3 postion)
    {
        return InstantiatePoolObject<Transform>(table, postion, Quaternion.identity , new Vector3(-100, -100, -100)).gameObject;
    }
}
