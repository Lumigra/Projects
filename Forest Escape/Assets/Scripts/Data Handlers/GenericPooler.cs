using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenericPooler<T> : MonoBehaviour where T : MonoBehaviour
{
    public List<T> ObjectTypes = new List<T>();

    protected List<T> DeployedObjects = new List<T>();
    protected List<T> PooledObjects = new List<T>();

    public void AddObject(T obj)
    {
        DeployedObjects.Add(obj);
    }

    public T GetObject(int num)
    {
        if (PooledObjects.Count == 0) return null;
        T toSpawn = null;

        toSpawn = PooledObjects.Find(x => x.GetType() == ObjectTypes[num].GetType());
        if(toSpawn != null)
        {
            DeployedObjects.Add(toSpawn);
            PooledObjects.Remove(toSpawn);
            toSpawn.gameObject.SetActive(true);
        }
        return toSpawn;
    }

    public void PoolObject(T obj)
    {
        DeployedObjects.Remove(obj);
        PooledObjects.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
