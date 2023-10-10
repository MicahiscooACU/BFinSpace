using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatBackround : MonoBehaviour
{

    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < startPos.y - 13.1)
        {
            transform.position = startPos;
        }
    }
}
