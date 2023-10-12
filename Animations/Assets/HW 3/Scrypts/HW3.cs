using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW3 : MonoBehaviour
{
    public GameObject Child;
    public GameObject Parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddSwordAsChild()
    {
        Child.transform.parent = Parent.transform;
    }
}
