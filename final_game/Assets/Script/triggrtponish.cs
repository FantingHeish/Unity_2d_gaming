using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggrtponish : MonoBehaviour
{
    public GameObject life;
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
            Blood.blood--;
        }
        //Destroy(gameObject);
        //Blood.blood--;

    }

}
