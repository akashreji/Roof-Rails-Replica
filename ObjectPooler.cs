using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class LogPool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (LogPool logPool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < logPool.size; i++)
            {
                GameObject obj = Instantiate(logPool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(logPool.tag, objectPool);
        }
    }

    public List<LogPool> pools;
    
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
       
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("pool with tag" + tag + "doesnt exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation= rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

       return objectToSpawn;
    }
    void Update()
    {
       
    }
}
