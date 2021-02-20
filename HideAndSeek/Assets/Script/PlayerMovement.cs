using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float zaxis = Input.GetAxis("Vertical");
       gameObject.transform.position = new Vector3 (transform.position.x + (horizontal  * 4.0f), 
      transform.position.y , transform.position.z + (zaxis *4.0f));
        
    }
}
