using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backrouder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("MyFunction", 3);
       
        
    }
    void MyFunction()
{
      Vector3 newScale = transform.localScale;
newScale *= 1.0001f;
transform.localScale = newScale;
}

  
    
}

