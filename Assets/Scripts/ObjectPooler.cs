using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pooledObjects;

    [System.Serializable]
    public class ObjectPoolItem
    {
        public int amountToPool;
        public GameObject objectToPool;
        public bool shouldExpand;
    }
    public List<ObjectPoolItem> itemsToPool;

    public static ObjectPooler SharedInstance;

    void Awake()
    {
        //Makes this script public so any script can reference this script.
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        //For each object in itemsToPool instatiates them, sets them inactive and adds them to the pooledObjects list.
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }


    public GameObject GetPooledObject(string tag)
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //Checks if there is enough objects inactive in the scene.
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                //If there is not enough items to use it will create more.
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

}
