using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Manager { get; private set; }

    //[HideInInspector]
    public List<MonoBehaviour> singletons = new List<MonoBehaviour>();
    private void Awake()
    {
        Manager = this;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    private void SceneUnloaded(Scene scene)
    {
        foreach(MonoBehaviour singleton in singletons.ToList())
        {
            if(singleton.gameObject.scene == scene)
            {
                singletons.Remove(singleton);
            }
        }
    }

    public void Register<T>(T param) where T : MonoBehaviour
    {
        if(!singletons.Exists(s => s is T)) singletons.Add(param);
    }

    public void Unregister<T>(T param) where T : MonoBehaviour
    {
        if(singletons.Exists(s => s is T)) singletons.Remove(param);
    }

    public T GetSingleton<T>() where T : MonoBehaviour
    {
        T temp = null;
        for(int x = 0; x < singletons.Count; x++)
        {
            if(singletons[x] is T)
            {
                temp = singletons[x] as T;
                break;
            }
        }
        return temp;
    }

    private void OnDestroy()
    {
        singletons.Clear();
    }
}
