using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    bool coordX;
    bool coordY;

	int Force = 2;
	int DegreesSec = 100;

    Vector2 Direction = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float TrInput = Input.GetAxis("Vertical");
        if (TrInput != 0)
        {
            rigidbody.AddForce(Force * Direction);
        }
    }

    void OnBecameVisible()
    {
        coordX = true;
        coordY = true;
    }

    void OnBecameInvisible()
    {
        Vector2 position = transform.position;
        if (coordX)
        {
            if (position.x > ScreenUT.ScreenRight)
            {
                position.x = ScreenUT.ScreenRight - position.x + ScreenUT.ScreenLeft;
                transform.position = position;
                coordX = false;
            }
            else if (position.x < ScreenUT.ScreenLeft)
            {
                position.x = ScreenUT.ScreenLeft - position.x + ScreenUT.ScreenRight;
				transform.position = position;
				coordX = false;
            }
        }
        if (coordY)
        {
            if (position.y > ScreenUT.ScreenTop)
            {
                position.y = ScreenUT.ScreenTop - position.y + ScreenUT.ScreenBottom;
                transform.position = position;
                coordY = false;
            }
            else if (position.y < ScreenUT.ScreenBottom)
            {
                position.y = ScreenUT.ScreenBottom - position.y + ScreenUT.ScreenTop;
				transform.position = position;
				coordY = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float RotInput = Input.GetAxis("Horizontal");
        float RotAmount = DegreesSec * Time.deltaTime * RotInput;
        //if (RotInput < 0)
            //RotAmount *= -1;
        transform.Rotate(Vector3.forward, RotAmount);
        float angle = Mathf.Deg2Rad * transform.eulerAngles.z;
        Direction.x = Mathf.Sin(-angle);
        Direction.y = Mathf.Cos(-angle);
    }
}
