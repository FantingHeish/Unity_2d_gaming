using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Idle (1)")
        {
            Destroy(gameObject);
            Blood.score= Blood.score+10;
        }
        //Destroy(gameObject);
        //Blood.score = Blood.score + 10;
    }
}
