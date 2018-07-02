using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    #region SINGLETON
    public static ObjectPooler _instance;
    public static ObjectPooler Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<ObjectPooler>();
                if (_instance == null) {
                    GameObject container = new GameObject("ObjectPooler");
                    _instance = container.AddComponent<ObjectPooler>();
                }
            }
            return _instance;
        }
    }

    void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);

        InstantiatePool();
    }
    #endregion

    [System.Serializable]
    public class Pool {

        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void InstantiatePool() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public virtual GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        if (poolDictionary.ContainsKey(tag)) {

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

            if (pooledObject != null) {
                pooledObject.OnObjectSpawn();
            }

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        } else {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }

    }
}
