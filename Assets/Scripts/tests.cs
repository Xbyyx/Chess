using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = new GameObject("go",typeof(Rigidbody), typeof(BoxCollider)); 
    }
}
