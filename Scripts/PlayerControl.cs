using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    public GameObject anima;
    Animator anim;
    static readonly string GameSave = "ss.json";
    public static Rigidbody2D rigidBody;
    public float moveSpeed;
    bool isFacingRight = true;
    public static bool isGrounded = false;
    public static bool isGroundedAlt = false;
    public static bool isDropped = false;
    public static bool isDroppedAlt = false;
    public static bool isBlockEnter1 = false;
    public static bool isBlockEnter2 = false;
    public static bool isBlockEnter3 = false;
    public static bool isBlockEnter4 = false;
    public static bool isBlockEnter5 = false;
    public static bool isBlockEnter6 = false;
    public Transform groundCheck;
    public Transform groundCheckScale;
    public Transform blockCheckScale;
    float groundRadius = 90;
    public LayerMask whatIsGround;
    public LayerMask whatIsDrop;
    public LayerMask whatIsBlock1;
    public LayerMask whatIsBlock2;
    public LayerMask whatIsBlock3;
    public LayerMask whatIsBlock4;
    public LayerMask whatIsBlock5;
    public LayerMask whatIsBlock6;
    public GameObject Pause;
    public static GameObject PauseM;
    int WallJumpCheck;
    public static float move;
    int abc=0;
    int f1=0;
    int f2=0;
    float a1;
    float a2;
    bool check1;
    bool check2;
    int deathcountC;
    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool b5 = false;
    bool b6 = false;
    bool HJ1 = false;
    bool HJ2 = false;
    public bool HighJump = false;
    public bool TimeWarp = false;
    float TC=1f;
    bool TCB=false;
    public float GravityScaleX = 0f;
    public float GravityScaleY = -3f;
    bool scaleCheck;
    GameObject Player1;
    GameObject Player2;
    GameObject Player3;
    GameObject Player4;
    GameObject Player5;
    GameObject Player6;

    void Awake()
    {
        Physics2D.gravity = new Vector2(GravityScaleX, GravityScaleY);
    }
    void Start()
    {
        anim = anima.GetComponent<Animator>();
        anim.SetBool("DeathStart", true);
        PauseM=Pause;
        rigidBody = GetComponent<Rigidbody2D>();
        PlayerOnCollision.p_isDestroyed = false;
        if (TimeWarp)
        {
            Invoke("T1",0f);
        }
        transform.localScale=new Vector3(83.75151f, 83.75151f, 83.75151f);
        transform.Rotate(0f, 0.0f, 0.0f);
        Invoke("SC",0.5f);
        Player1=OpenLocation.Player1;
        Player2=OpenLocation.Player2;
        Player3=OpenLocation.Player3;
        Player4=OpenLocation.Player4;
        Player5=OpenLocation.Player5;
        Player6=OpenLocation.Player6;
    }

    void FixedUpdate()
    {
        if (PlayerOnCollision.p_isDestroyed == false)
        {
            Run();
            isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckScale.localScale, groundRadius, whatIsGround);
            isDropped = Physics2D.OverlapBox(groundCheck.position, groundCheckScale.localScale, groundRadius, whatIsDrop);
            isBlockEnter1 = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsBlock1);
            isBlockEnter2 = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsBlock2);
            isBlockEnter3 = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsBlock3);
            isBlockEnter4 = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsBlock4);
            isBlockEnter5 = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsBlock5);
            isBlockEnter6 = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsBlock6);
            
        }
    }
    void SC()
    {
        scaleCheck=true;
    }
    void Run()
    {
        if (PlayerOnCollision.p_isDestroyed == false)
        {
            if (isDropped)
            {
                move=0;
            }
            else
            {
                if (isDroppedAlt)
                {
                    move=0;
                }
                else
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        move = Input.GetAxis("Horizontal") * 0.085f;
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        move = Input.GetAxis("Horizontal") * 0.085f*0.95f;
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        move = Input.GetAxis("Horizontal") * 0.085f*0.87f;
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        move = Input.GetAxis("Horizontal") * 0.085f*0.76f;
                    }
                }
            }
            a2=a1;
            a1=move;
            rigidBody.velocity = new Vector2(move * (moveSpeed - 5), rigidBody.velocity.y);

            if (move > 0 && !isFacingRight)
            {
            Flip();
            }
            else if (move < 0 && isFacingRight)
            {
            Flip();
            }
//            if (move < 0)
//            {
//            CancelInvoke("Flipping11");
//            check1=false;
//            if (!check2)
//            {
//            InvokeRepeating("Flipping22",0f,0.001f);
//            check2=true;
//            }
//            }
//            if (move > 0)
//            {
//            CancelInvoke("Flipping22");
//            check2=false;
//            if (!check1)
//            {
//            InvokeRepeating("Flipping11",0f,0.001f);
//            check1=true;
//            }
//            }
//
//            if (move > 0 && a2>a1)
//            {
//                CancelInvoke("Flipping11");
//                check1=false;
//            }
//            if (move < 0 && a2<a1)
//            {
//                CancelInvoke("Flipping22");
//                check2=false;
//            }
//            if (move == 0)
//            {
//                CancelInvoke("Flipping11");
//                check1=false;
//                CancelInvoke("Flipping22");
//                check2=false;
//            }
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= 1;
        transform.localScale = theScale;
    }

    void FlipJump()
    {
            if (isFacingRight)
            {
                if (Physics2D.gravity == new Vector2(0, 2))
                {
                InvokeRepeating("Flipping2",0f,0.01f);
                }
                else
                {
                InvokeRepeating("Flipping1",0f,0.01f);
                }
            }
            else
            {
                if (Physics2D.gravity == new Vector2(0, 2))
                {
                InvokeRepeating("Flipping1",0f,0.01f);
                }
                else
                {
                InvokeRepeating("Flipping2",0f,0.01f);
                }
            }
            HJ1=false;
            HJ2=false;
    }
    void Flipping1()
    {
        f1+=5;
        transform.Rotate(0,0,-5);
        if (f1==90)
        {
            CancelInvoke("Flipping1");
            f1 = 0;
        }
        if (transform.lossyScale != new Vector3(0.6f, 0.6f, 0.6f) && Camera.main.aspect >=1.6807)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        if (transform.lossyScale != new Vector3(0.5f, 0.5f, 0.5f) && Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (transform.lossyScale != new Vector3(0.4f, 0.4f, 0.4f) && Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        if (transform.lossyScale != new Vector3(0.3f, 0.3f, 0.3f) && Camera.main.aspect <1.0697)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
    void Flipping2()
    {
        f2+=5;
        transform.Rotate(0,0,5);
        if (f2==90)
        {
            CancelInvoke("Flipping2");
            f2 = 0;
        }
        if (transform.lossyScale != new Vector3(0.6f, 0.6f, 0.6f) && Camera.main.aspect >=1.6807)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        if (transform.lossyScale != new Vector3(0.5f, 0.5f, 0.5f) && Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        if (transform.lossyScale != new Vector3(0.4f, 0.4f, 0.4f) && Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }
        if (transform.lossyScale != new Vector3(0.3f, 0.3f, 0.3f) && Camera.main.aspect <1.0697)
        {
            ScaleBug();
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
    void ScaleBug()
    {
        if (Player1.activeSelf)
        Player1.transform.parent = null;
        if (Player2.activeSelf)
        Player2.transform.parent = null;
        if (Player3.activeSelf)
        Player3.transform.parent = null;
        if (Player4.activeSelf)
        Player4.transform.parent = null;
        if (Player5.activeSelf)
        Player5.transform.parent = null;
        if (Player6.activeSelf)
        Player6.transform.parent = null;
        
    }
    void Flipping11()
    {
        transform.Rotate(0,0,-1);
    }
    void Flipping22()
    {
        transform.Rotate(0,0,1);
    }
    IEnumerator MenuStartAsync() 
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
        if (asyncLoad.progress == 1f) 
            {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
            yield return null;
            }   
    }  
    void MSA()
    {
        StartCoroutine("MenuStartAsync");
        Buttons.isLoad=true;
    }     
    void Update()
    {
        if (PlayerOnCollision.p_isDestroyed == false)
        {
            //if (rigidBody.position.y<373.8)
            //Debug.Log(rigidBody.position.y);
            //Debug.Log(rigidBody.velocity.y);
            //16:9 = 1.771.., 16:10 = 1.6, 4:3 = 1.33.., 18:9 = 2, 21:9 = 2.334..
            //>16:9 = 0.6, 15:9--16:10 = 0.5, 4:3 = 0.4, 1:1 = 0.3
            //Debug.Log(transform.lossyScale);
            //Debug.Log(Camera.main.aspect);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //OpenLocation.Pos1.SetActive(false);
                //OpenLocation.Pos2.SetActive(false);
                //OpenLocation.Pos3.SetActive(false);
                //OpenLocation.Pos4.SetActive(false);
                //OpenLocation.Pos5.SetActive(false);
                //OpenLocation.Pos6.SetActive(false);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (!HighJump)
            {
            if (isGrounded && Input.GetKeyDown(KeyCode.W) && PauseM.activeSelf == false)
            {
                if (Physics2D.gravity == new Vector2(0, 2))
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f*0.76f));
                    }                
                }
                else
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f*0.76f));
                    }
                }
                DDONLOAD.soundData.Play();
                Invoke("FlipJump",0.1f);
            }

            if (isGroundedAlt && Input.GetKeyDown(KeyCode.W) && !isGrounded && PauseM.activeSelf == false)
            {
                if (Physics2D.gravity == new Vector2(0, 2))
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, -330f*0.76f));
                    }
                }
                else
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, 330f*0.76f));
                    }
                }
                DDONLOAD.soundData.Play();
                Invoke("FlipJump",0.1f);
            }
            }
            if (isGroundedAlt && Input.GetKeyDown(KeyCode.W) && !isGrounded && HighJump && PauseM.activeSelf == false)
            {
                if (Physics2D.gravity == new Vector2(0, 2))
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -300f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -300f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, -300f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, -300f*0.76f));
                    }
                }
                else
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 300f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 300f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, 300f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, 300f*0.76f));
                    }
                }
                DDONLOAD.soundData.Play();
                Invoke("FlipJump",0.1f);
                HJ1=true;
            }
            if (!HJ2 && !HJ1 && isGroundedAlt && Input.GetKeyDown(KeyCode.Space) && !isGrounded && HighJump && PauseM.activeSelf == false)
            {
                if (Physics2D.gravity == new Vector2(0, 2))
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -360f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, -360f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, -360f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, -360f*0.76f));
                    }
                }
                else
                {
                    if (Camera.main.aspect >=1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 360f));
                    }
                    if (Camera.main.aspect >=1.3752 && Camera.main.aspect <1.6807)
                    {
                        rigidBody.AddForce(new Vector2(0, 360f*0.95f));
                    }
                    if (Camera.main.aspect >=1.0697 && Camera.main.aspect <1.3752)
                    {
                        rigidBody.AddForce(new Vector2(0, 360f*0.87f));
                    }
                    if (Camera.main.aspect <1.0697)
                    {
                        rigidBody.AddForce(new Vector2(0, 360f*0.76f));
                    }
                }
                DDONLOAD.soundData.Play();
                Invoke("FlipJump",0.1f);
                HJ2=true;
            }

            if (Input.GetKeyDown(KeyCode.R) && PauseM.activeSelf == false)
            {
                Invoke("RestartTime", 0);
            }
            
            if (Input.GetKeyDown(KeyCode.P) && PauseM.activeSelf == false)
            {
                PauseM.SetActive(true);
                Invoke("CountP",0.01f);
                DDONLOAD.audioData.Pause();
                DDONLOAD.audioData2.Pause();
                DDONLOAD.audioData3.Pause();
                VideoPlay.BG.Pause();
                if (SceneManager.GetActiveScene().name=="20.2")
                {
                    GameObject.Find("Scripts").GetComponent<AudioSource>().Pause();
                }
            }

            if (Input.GetKeyDown(KeyCode.P) && PauseM.activeSelf == true  && abc == 1)
            {
                PauseM.SetActive(false);
                Time.timeScale = 1;
                abc =0;
                DDONLOAD.audioData.UnPause();
                DDONLOAD.audioData2.UnPause();
                DDONLOAD.audioData3.UnPause();
                VideoPlay.BG.Play();
                if (SceneManager.GetActiveScene().name=="20.2")
                {
                    GameObject.Find("Scripts").GetComponent<AudioSource>().UnPause();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && PauseM.activeSelf == false)
            {
                Buttons.isExit=true;
                GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
                GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
                Destroy(GetComponent<Rigidbody2D>());
                PlayerOnCollision.p_isDestroyed = true;
                Invoke("MSA",0.66f);
                PlayerOnCollision.anim.SetBool("DeathStart", false);
                //InvokeRepeating("Transform", 0f, 0.01f);
            }   

            if (isBlockEnter1 && !b1)
            {
                GameObject.Find("BlockPos1").SetActive(false);
                b1=true;
            }

            if (isBlockEnter2 && !b2)
            {
                GameObject.Find("BlockPos2").SetActive(false);
                b2=true;
            }

            if (isBlockEnter3 && !b3)
            {
                GameObject.Find("BlockPos3").SetActive(false);
                b3=true;
            }

            if (isBlockEnter4 && !b4)
            {
                GameObject.Find("BlockPos4").SetActive(false);
                b4=true;
            }

            if (isBlockEnter5 && !b5)
            {
                GameObject.Find("BlockPos5").SetActive(false);
                b5=true;
            }

            if (isBlockEnter6 && !b6)
            {
                GameObject.Find("BlockPos6").SetActive(false);
                b6=true;
            }
        }
    }

    void CountP()
    {
        abc=1;
        Time.timeScale = 0;
    }
    void RestartTime()
    {
        if (PlayerOnCollision.p_isDestroyed == false)
        {
            deathcountC = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).deathcount;
            deathcountC += 1;
            SaveData data = new SaveData()
            {
                scene = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).scene,
                pos = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).pos,
                m1 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m1,
                m2 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m2,
                m3 = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).m3,
                deathcount = deathcountC,
                p = JsonUtility.FromJson<SaveData>(File.ReadAllText(Path.Combine(Application.persistentDataPath, GameSave))).p
            };
            string json = JsonUtility.ToJson(data);
            string filename = Path.Combine(Application.persistentDataPath, GameSave);
            string jsonFromFile = File.ReadAllText(filename);
            SaveData copy = JsonUtility.FromJson<SaveData>(jsonFromFile);
            File.WriteAllText(filename, json);
            
            Destroy(GetComponent<Rigidbody2D>());
            PlayerOnCollision.p_isDestroyed = true;
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
            //InvokeRepeating("Transform", 0f, 0.001f);
            anim.SetBool("DeathStart", false);
            DDONLOAD.soundData2.Play();
            Invoke("RestartS", 0.6f);
        }
    }
    void RestartS()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }
    void Transform()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-0.1f, -0.1f, -0.1f), 0.05f);
        transform.Rotate(0,0,5);
    }

    void T1()
    {
        InvokeRepeating("T11",0f,0.5f);
    }
    void T11()
    {
        //Debug.Log(TC);
        Time.timeScale=TC;
        if (TC>0.9f && !TCB)
        {
        TC=TC-0.05f;
        }
        else
        { TCB=true;
        if (TC<1.2f && TCB)
        {
            TC=TC+0.05f;
        }
        else
        {
            TCB=false;
        }
        
        }
    }
}