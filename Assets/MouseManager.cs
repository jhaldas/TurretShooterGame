using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject selectedObject;

    public Player player;

    public SelectionIndicator objectTarget;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();

        objectTarget = GameObject.FindObjectOfType<SelectionIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject hitObject = hitInfo.transform.root.gameObject;
                if (hitInfo.transform.gameObject.tag == "Building" || hitInfo.transform.gameObject.tag == "Enemy")
                {
                    SelectObject(hitObject);
                    player.MovePlayer(hitInfo, 1);
                }
                else
                {
                    player.MovePlayer(hitInfo, 0);
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
}
