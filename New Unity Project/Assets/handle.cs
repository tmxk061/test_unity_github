using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    Vector3 StartMouse = new Vector3();

    public void RotateHandle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("Player").GetComponent<Player>().move = false;
            StartMouse = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 UpdateMouse = Input.mousePosition;

            if (StartMouse.x > UpdateMouse.x)
            {
                this.transform.Rotate(0, 0, 40 * Time.deltaTime);
                GameObject.Find("Ship").GetComponent<ship>().transform.Rotate(0, -5 * Time.deltaTime, 0);
            }
            else if (StartMouse.x < UpdateMouse.x)
            {
                this.transform.Rotate(0, 0, 40 * Time.deltaTime *-1);
                GameObject.Find("Ship").GetComponent<ship>().transform.Rotate(0, 5 * Time.deltaTime, 0);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            GameObject.Find("Player").GetComponent<Player>().move = true;
        }
    }
}
