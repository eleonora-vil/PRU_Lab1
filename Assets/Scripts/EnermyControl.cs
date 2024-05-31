using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnermyControl : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the enermy position
        Vector2 position = transform.position;

        //Compute the enermy new position
        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

        //Update the enemy position
        transform.position = position;

        //this is the bottom-left point of the screen 
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

        //if the enermy went outside the screen on the bottom, then destroy the enermy
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}
