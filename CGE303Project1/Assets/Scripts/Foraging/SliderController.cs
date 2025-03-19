using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public int speed; // set in the inspector (the speed of the moving object)


   
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0); // moves the object left or right based on the speed variable
    }

    private void OnCollisionEnter2D(Collision2D collision) // activates when the object collides with another object
    {
        if (collision.gameObject.tag == "wall") // check if the object collided with was a wall
        {
            speed *= -1; // reverse the direction of the object
        }
    }
}
