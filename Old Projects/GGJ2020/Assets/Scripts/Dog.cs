using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Dog : MonoBehaviour
{
    public float Speed;
    public float Offset;

    public bool willChase;

    public InteractableObjects target;
    private InteractableObjectsHandler handler;

    private void Start()
    {
        if (InteractableObjectsHandler.IObjHandler == null)
        {
            throw new UnityException("No Object List");
        }

        handler = InteractableObjectsHandler.IObjHandler;

        SetDestination();
    }

    private void Update()
    {
        if (GameManager.Manager.IsGamePaused)
            return;

        if (!willChase)
            return;
        if(hasReachedDestination())
        {
            SetDestination();
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Speed * Time.deltaTime);
        //SetDestination();
    }

    public InteractableObjects GetTarget() => target;


    void SetDestination()
    {
        List<InteractableObjects> iObjects = handler.GetList().ToList();
        if (target != null)
            iObjects.RemoveAll(t => t == target);

        int selected = Random.Range(0, iObjects.Count);
        target = iObjects[selected];

    }

    private float GetDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position);
    }

    bool hasReachedDestination()
    {
        if (GetDistance() <= Offset)
            return true;
        return false;
    }
}
