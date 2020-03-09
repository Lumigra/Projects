using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class OnAllObjDestroyed : UnityEvent { }
public class InteractableObjectsHandler : MonoBehaviour
{
    public OnAllObjDestroyed allObjDestroyed = new OnAllObjDestroyed();

    public static InteractableObjectsHandler IObjHandler;

    public List<InteractableObjects> IObjList;

    private void Awake()
    {
        if (IObjHandler != null)
            Destroy(gameObject);
        IObjHandler = this;
    }

    private void Start()
    {
        foreach(InteractableObjects obj in IObjList)
        {
            obj.destroyed.AddListener(OnObjDestroyed);
        }
    }

    void OnObjDestroyed()
    {
        if (IObjList.All(o => o.isBroken))
            allObjDestroyed.Invoke();
    }

    public List<InteractableObjects> GetList() => IObjList;

    public int GetListSize() => IObjList.Count;

    public InteractableObjects GetObject(int selected) => IObjList[selected];
}
