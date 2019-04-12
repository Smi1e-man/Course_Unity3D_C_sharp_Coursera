using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    Renderer Renderer;
    bool Check = false;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<Renderer>();
        Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Renderer.isVisible)
            Check = true;
        if (Check)
        {
            if (!Renderer.isVisible)
            {
				Destroy(gameObject);            
            }
        }
    }
}
