using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drag()
    {
        //GameObject.Find("image").transform.position = Input.mousePosition;
        print("Dragging");
        gameObject.transform.position = Input.mousePosition;

    }

    public void Drop()
    {
        checkMatch();
    }

    public void checkMatch()
    {
        //GameObject ph1 = GameObject.Find("PH1");
        //GameObject img = GameObject.Find("image");
        GameObject img = gameObject;
        string tag = gameObject.tag;
        GameObject ph1 = GameObject.Find("PH" + tag);
        float distance = Vector3.Distance(ph1.transform.position, img.transform.position);
        print("Distance" + distance);
        if (distance <= 50)
        {
                snap(img, ph1);
        }
        else
                moveBack();
    }

    public void moveBack()
    {
        transform.position = originalPosition;
    }

    public void snap(GameObject img, GameObject ph)
    {
        img.transform.position = ph.transform.position;
    }

    public void initCardPosition()
    {
        originalPosition = transform.position;
    }
}
