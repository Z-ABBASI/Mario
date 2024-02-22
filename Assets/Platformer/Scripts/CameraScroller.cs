using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public GameObject Mario;
    private float offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - Mario.transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mario.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
