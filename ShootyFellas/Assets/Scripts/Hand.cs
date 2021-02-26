using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Camera Main;

    public GameObject Parent;

    public float OffsetDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Main = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.mousePosition);
        Vector3 Worldpos = Input.mousePosition;

        Worldpos = new Vector3(Worldpos.x, Worldpos.y, 10);
        Worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Worldpos = new Vector3(Worldpos.x, Worldpos.y, Parent.transform.position.z);
        Debug.Log(Worldpos);


        transform.position = Parent.transform.position + (Worldpos - Parent.transform.position).normalized *OffsetDistance;
       // Debug.Log(Camera.main.ScreenToWorldPoint(Worldpos));
       // Debug.Log(Main.ScreenToWorldPoint(Input.mousePosition));
    }
}
