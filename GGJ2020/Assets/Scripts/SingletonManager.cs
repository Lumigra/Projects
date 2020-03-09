using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonManager : MonoBehaviour
{
    public static SingletonManager Manager;
    private List<MonoBehaviour> singletons = new List<MonoBehaviour>();
    // Start is called before the first frame update
    void Awake()
    {
        if (Manager != null)
            Destroy(gameObject);
        Manager = this;
        SceneManager.sceneUnloaded += SceneUnloaded;
    }

    private void SceneUnloaded(Scene scene)
    {
        for (int x = 0; x < singletons.Count; x++)
        {
            if(singletons[x].gameObject.scene == scene)
            {
                Unregister(singletons[x]);
                //singletons.Remove(singletons[x]);
            }
        }
    }

    public void Register<T>(T param) where T : MonoBehaviour
    {
        if (!singletons.Exists(s => s is T)) singletons.Add(param);
    }

    public void Unregister<T>(T param) where T : MonoBehaviour
    {
        singletons.RemoveAll(s => s is T);
    }

    public T GetSingleton<T>() where T : MonoBehaviour
    {
        T temp = null;
        for (int x = 0; x < singletons.Count; x++)
        {
            if (singletons[x] is T)
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
