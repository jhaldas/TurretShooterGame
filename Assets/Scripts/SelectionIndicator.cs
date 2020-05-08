using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    MouseManager mm;
    private Vector3 offset;
    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<MouseManager>();
        offset = new Vector3(0, 0.01f, 0);
        selectedObject = null;
    }

    public void SetTarget(GameObject target)
    {
        selectedObject = target;
    }

    // Update is called once per frame
    void Update()
    {
        selectedObject = mm.selectedObject;

        if (selectedObject != null)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
            this.transform.position = new Vector3(selectedObject.transform.position.x, 0.01f, selectedObject.transform.position.z);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
