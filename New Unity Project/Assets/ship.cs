using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
       this.gameObject.transform.Translate(new Vector3(40 * Time.deltaTime, 0, 0));

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -5 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 5 * Time.deltaTime, 0);
        }
    }
}
