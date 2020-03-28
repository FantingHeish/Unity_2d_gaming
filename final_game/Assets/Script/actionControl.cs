using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class actionControl : MonoBehaviour
{
    public Text mouse;

    public Animator _actionController;
    CharacterController controller;
    public float speed = 3;
    //---------動畫-----------
    public bool _idle;
    public bool _run;
    public bool _melee;
    public bool _jump;
    public bool _dead;
    //---------道具食物-----------
    public GameObject medicine;
    public GameObject treasure;
    public GameObject poison;
    //public GameObject protection;
    private int[] conYaxis = { -2, 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34, 37, 40 };//控制物件生成在地板的y軸
    //private int[] conYaxis = { -2, 4, 10, 16, 22, 28, 34 };//控制物件生成在地板的y軸
    //-------子彈-------
    public GameObject built;
    //--------血量-------
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    //-----------分數--------------
    public Text scoretext;
    //----------結束畫面----------
    public GameObject menuContaner;
    public GameObject menuContaner_win;
    // Start is called before the first frame update
    void Start()
    {
        _actionController = gameObject.GetComponent<Animator>();
        //controller = GetComponent<CharacterController>();
        //------------生成毒果-----------------
        //int[] randomCheck = new int[5];
        for (int i = 0; i <= 6; i++)
        {
            int x = (int)Random.Range(-10, 10);
            int yaxis = (int)Random.Range(0, 14);
            //randomCheck[i] = yaxis;
            int y = conYaxis[yaxis];
            /*
            for(int j = 0; j < i; j++)
            {
                while(randomCheck[j]!= randomCheck[i])
                {
                    yaxis = (int)Random.Range(0, 14);
                    y = conYaxis[yaxis];
                }
            }
            */
            Instantiate(poison, new Vector2(x, y), Quaternion.identity);
        }
        //-------------生成寶藏----------------------
        for (int i = 0; i <= 6; i++)
        {
            int x = (int)Random.Range(-10, 10);
            int yaxis = (int)Random.Range(0, 14);
            int y = conYaxis[yaxis];
            Instantiate(treasure, new Vector2(x, y), Quaternion.identity);
        }
        //----------------生成藥水-------------------
        /*
        for (int i = 0; i < 1; i++)
        {
            int x = (int)Random.Range(-10, 10);
            //int yaxis = (int)Random.Range(0, 14);
            //int y = conYaxis[yaxis];
            Instantiate(medicine, new Vector2(x, 25), Quaternion.identity);
        }
        */
        //----------------生成保護衣--------------------------
        /*
        for (int i = 0; i < 1; i++)
        {
            int x = (int)Random.Range(-10, 10);
            //int yaxis = (int)Random.Range(0, 14);
            //int y = conYaxis[yaxis];
            Instantiate(protection, new Vector2(x, 16), Quaternion.identity);
        }
        */
    }





    // Update is called once per frame
    void Update()
    {

        _actionController.SetBool("Idle", _idle);
        _actionController.SetBool("Run", _run);
        _actionController.SetBool("Melee", _melee);
        _actionController.SetBool("Jump", _jump);
        _actionController.SetBool("Dead", _dead);
        //-------------------------
        //----------跑-----------
        if (Input.GetKey(KeyCode.D))
        {
            //controller.Move(new Vector2(speed*Time.deltaTime,0));
            this.transform.eulerAngles = Vector2.zero;
            //this.transform.Translate(3 * Time.deltaTime, 0, 0);
            //取得目前方向
            Vector3 moveDirection = transform.right;
            transform.position += moveDirection * Time.deltaTime *speed;
            // this.transform.Translate(Vector2.right*0.08f);
            _run = true;

            _idle = false;
            _melee = false;
            _jump = false;
            _dead = false;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            IDLE();
        }

        //--------------------
        if (Input.GetKey(KeyCode.A))
        {
            // controller.Move(new Vector2(-speed * Time.deltaTime, 0));
            transform.eulerAngles = new Vector2(0,180);
            //this.transform.Translate(-3 * Time.deltaTime, 0, 0);
            Vector3 moveDirection = transform.right;
            transform.position += moveDirection * Time.deltaTime * speed;
            //this.transform.Translate(Vector2.left * 0.08f);

            _run = true;

            _idle = false;
            _melee = false;
            _jump = false;
            _dead = false;


        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            IDLE();
        }

        //---------跳-------------
        if (Input.GetKey(KeyCode.W))
        {
            //controller.Move(new Vector2(0, speed * Time.deltaTime));
            transform.Translate(Vector2.up * 0.15f);
            _jump = true;

            _idle = false;
            _run = false;
            _melee = false;
            _dead = false;


        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            IDLE();
        }
        //---------滑鼠攻擊--------
        if (Input.GetMouseButtonDown(0)) // 0:滑鼠左鍵。偵測是否按下。
        {
            float v2 = Input.mousePosition.x;
            //mouse.text = v2.ToString();//顯示滑鼠x軸位置
            //float posidle = this.transform.position.x;
            if (v2 >= 465)//右
            {
                transform.eulerAngles = Vector2.zero;
                _melee = true;

                _idle = false;
                _run = false;
                _jump = false;
                _dead = false;
                Vector2 posbuilt = gameObject.transform.position + new Vector3(0.5f, 0);
                Instantiate(built, posbuilt, gameObject.transform.rotation);
            }
            else//左
            {
                transform.eulerAngles = new Vector2(0, 180);
                _melee = true;

                _idle = false;
                _run = false;
                _jump = false;
                _dead = false;
                Vector2 posbuilt = gameObject.transform.position + new Vector3(-0.5f, 0);
                Instantiate(built, posbuilt, gameObject.transform.rotation);
            }
            
            

        }
        if (Input.GetMouseButtonUp(0))
        {
            IDLE();
        }

        //------------扣血----------------
        if (Blood.blood == 2)
        {
            Destroy(life1);
        }
        if (Blood.blood == 1)
        {
            Destroy(life2);
        }
        if (Blood.blood == 0)
        {
            _dead =true;

            _idle = false;
            _run = false;
            _melee = false;
            _jump = false;
           
            Destroy(life3);
            //跳出gameover畫面
            menuContaner.SetActive(true);

        }
        if (transform.position.y < -4 || transform.position.x<-11.5 || transform.position.x>11.5)
        {
            menuContaner.SetActive(true);//如果掉出也死掉
        }
        //-----------回血-----------------
        /**
        if (Blood.bloodmedic == 1)
        {
            if((Blood.blood == 2){
                Instantiate(medicine, new Vector2(x, 25), Quaternion.identity);
            }
           
        }
        */
        //-------------分數----------------
        scoretext.text = "SCOER :  "+Blood.score.ToString();
        //-----------------------------


    }
    private void IDLE()
    {
        _idle = true;

        _run = false;
        _melee = false;
        _jump = false;
        _dead = false;
    }
    /*
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "0_Golem_Run Throwing_006 (4)")
        {
            print("enmeyf2");
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D aaa)
    {
        //碰到敵人
        if (aaa.gameObject.name == "9" ||
            aaa.gameObject.name == "9 (1)" || 
            aaa.gameObject.name == "9 (2)" || 
            aaa.gameObject.name == "9 (3)" ||
            aaa.gameObject.name == "9 (4)" || 
            aaa.gameObject.name == "9 (5)" ||
            aaa.gameObject.name == "9 (6)" ||
            aaa.gameObject.name == "8" ||
            aaa.gameObject.name == "8 (1)" || 
            aaa.gameObject.name == "8 (2)" ||
            aaa.gameObject.name == "8 (3)" ||
            aaa.gameObject.name == "8 (4)" ||
            aaa.gameObject.name == "8 (5)" ||
            aaa.gameObject.name == "8 (6)" ||
            aaa.gameObject.name == "8 (7)" ||
            aaa.gameObject.name == "37" ||
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
            Destroy(aaa.gameObject);
            Blood.blood--;
            _dead = true;

            _idle = false;
            _run = false;
            _melee = false;
            _jump = false;
            
        }
        else
        {
            IDLE();
        }
        
        if(aaa.gameObject.name== "door")
        {
            menuContaner_win.SetActive(true);
        }
        
    }





}
