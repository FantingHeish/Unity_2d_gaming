using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bilt : MonoBehaviour
{
    //public GameObject Built;
    //private float speed = 1.0f;
    private float vdic;
    public Text mouse;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) // 0:滑鼠左鍵。偵測是否按下。
        //{
            vdic = Input.mousePosition.x;
            //mouse.text = vdic.ToString();//顯示滑鼠x軸位置
        //}
            
        //transform.Translate(Vector3.right * Time.deltaTime * 0.1f, Space.Self);
        //Vector3 moveDirection = transform.right;
        //transform.position += moveDirection * Time.deltaTime * speed;
        if (vdic >= 465)//右
        {
            gameObject.transform.position += new Vector3(0.1f, 0, 0);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            gameObject.transform.position += new Vector3(-0.1f, 0, 0);
            Destroy(gameObject, 0.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D aaa)
    {
        if (aaa.gameObject.name == "9" ||
            aaa.gameObject.name == "9 (1)" ||
            aaa.gameObject.name == "9 (2)" ||
            aaa.gameObject.name == "9 (3)" ||
            aaa.gameObject.name == "9 (4)" ||
            aaa.gameObject.name == "9 (5)" ||
            aaa.gameObject.name == "9 (6)")
            {
                //print("enmey9");
                Destroy(gameObject);
                Destroy(aaa.gameObject);
                Blood.score = Blood.score + 10;
            }

        if (aaa.gameObject.name == "8" ||
            aaa.gameObject.name == "8 (1)" ||
            aaa.gameObject.name == "8 (2)" ||
            aaa.gameObject.name == "8 (3)" ||
            aaa.gameObject.name == "8 (4)" ||
            aaa.gameObject.name == "8 (5)" ||
            aaa.gameObject.name == "8 (6)" ||
            aaa.gameObject.name == "8 (7)" )
            {
                //print("enmey9");
                Destroy(gameObject);
                Destroy(aaa.gameObject);
                Blood.score = Blood.score + 20;
            }
            if (aaa.gameObject.name == "37" ||
                aaa.gameObject.name == "37 (1)" ||
                aaa.gameObject.name == "37 (2)" ||
                aaa.gameObject.name == "37 (3)" ||
                aaa.gameObject.name == "37 (4)" ||
                aaa.gameObject.name == "37 (5)" ||
                aaa.gameObject.name == "37 (6)" ||
                aaa.gameObject.name == "37 (7)" ||
                aaa.gameObject.name == "37 (8)")
            {
                //print("enmey9");
                Destroy(gameObject);
                Destroy(aaa.gameObject);
                Blood.score = Blood.score + 30;
            }
    }
        
}
