using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmetMove3 : MonoBehaviour
{
    private float speed = 2.5f;
    //public GameObject traget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (gameObject.transform.position.x > 10)
        {
            speed = -2.5f;

            //transform.eulerAngles = Vector2.zero;
        }

        if (gameObject.transform.position.x < -10)
        {
            speed = 2.5f;
            //transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
