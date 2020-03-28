using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyMove2 : MonoBehaviour
{
    private float speed = 2.0f;
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
            speed = -2.0f;
            //transform.eulerAngles = Vector2.zero;
        }

        if (gameObject.transform.position.x < -10)
        {
            speed = 2.0f;
            //transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
