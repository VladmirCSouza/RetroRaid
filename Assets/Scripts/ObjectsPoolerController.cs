using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsable for pooling instantiation of enemies  and fuel
/// </summary>

public class ObjectsPoolerController : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string tag; //The name of the pool
        public GameObject prefab; //The gameobject type of the pool
        public int size; //How many objects will be in the pool
    }

    public static ObjectsPoolerController Instance;

    public void Awake()
    {
        Instance = this;
        Init();
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    
	// Use this for initialization
	void Start () {
        
	}

    private void Init()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary == null)
            return null;
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
