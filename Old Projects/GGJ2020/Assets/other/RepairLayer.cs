using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnObjectClicked : UnityEvent<bool> { }
public class RepairLayer : MonoBehaviour
{
    public OnObjectClicked clicked = new OnObjectClicked();

    GameObject myEventSystem;
    // Start is called before the first frame update
    void Start()
    {
        myEventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            //if (hit.collider != null)
            //{
            for(int x = 0; x < hits.Length; x++)
            { 
                if (hits[x].collider.gameObject != gameObject)
                    return;

                Debug.Log(hits[x].collider.gameObject.name);

                if (hits[x].collider.gameObject.tag == "Sew" && Repair.Instance.IsHammer)
                {
                    clicked.Invoke(true);
                    //Debug.Log("Item Repaired");
                }
                else if (hits[x].collider.gameObject.tag == "Glue" && Repair.Instance.IsGlue)
                {
                    clicked.Invoke(true);
                    //Debug.Log("Item Repaired");
                }
                else if (hits[x].collider.gameObject.tag == "Hand" && Repair.Instance.IsHand)
                {
                    clicked.Invoke(true);
                    //Debug.Log("Item Repaired");
                }
                else if (hits[x].collider.gameObject.tag == "Rag" && Repair.Instance.IsRag)
                {
                    clicked.Invoke(true);
                    //Debug.Log("Item Repaired");
                }
                else if (hits[x].collider.gameObject.tag == "Bag" && Repair.Instance.IsBag)
                {
                    clicked.Invoke(true);
                    //Debug.Log("Item Repaired");
                }
                else if (hits[x].collider.gameObject.tag == "Tape" && Repair.Instance.IsTape)
                {
                    clicked.Invoke(true);
                    //Debug.Log("Item Repaired");
                }
                else
                {
                    clicked.Invoke(false);
                    //Debug.Log("Wrong Tool");
                }

                Repair.Instance.DisableAllModes();
            }
        }
    }
}
 

