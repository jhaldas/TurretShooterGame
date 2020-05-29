using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseManager : MonoBehaviour
{
    public GameObject selectedObject;

    public PlayerController player;

    public SelectionIndicator objectTarget;

    public LayerMask movementMask;

    public Vector3 target;

    public GameObject temp;

    public PlayerManager playerManager;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        objectTarget = GameObject.FindObjectOfType<SelectionIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo, 100))
            {
                GameObject hitObject = hitInfo.transform.root.gameObject;

                Debug.Log("Hit "+ hitInfo.transform.gameObject.tag);

                if (hitInfo.transform.gameObject.GetComponent<Interactable>() != null)
                {
                    if (hitInfo.transform.gameObject.tag == "Building")
                    {
                        // MAKES PLAYER WALK TO CLOSEST POINT ON RADIUS OF TARGET
                        target = playerManager.player.transform.position - hitInfo.transform.gameObject.transform.position;
                        target = target.normalized;
                        target *= hitInfo.transform.gameObject.GetComponent<Interactable>().radius;
                        target += hitInfo.transform.gameObject.transform.position;
                    }
                    else if (hitInfo.transform.gameObject.tag == "Enemy")
                    {
                        target = playerManager.player.transform.position - hitInfo.transform.gameObject.transform.position;

                        if (target.magnitude > player.attackRange)
                        {
                            target = target.normalized;
                            target *= player.attackRange;
                            target += hitInfo.transform.gameObject.transform.position;
                        }
                        else
                        {
                            target = player.transform.position;
                        }
                    }

                    player.SetFocus(hitInfo.transform.gameObject.GetComponent<Interactable>());
                    SelectObject(hitObject);
                    //player.FollowTarget(focus);
                    player.MovePlayer(target, 1);

                }
                else
                {
                    player.RemoveFocus();
                    player.MovePlayer(hitInfo.point, 0);
                    ClearSelection();
                }
            }
        }
    }



    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            if (obj == selectedObject) return;

            ClearSelection();
        }

        selectedObject = obj;

    }

    void ClearSelection()
    {
        selectedObject = null;
    }

    /*
    public void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        newFocus.OnFocused(transform);
        newFocus.OnFocused(transform);
    }
    */

    /*
    public void RemoveFocus()
    {
        focus = null;
    }
    */

}
