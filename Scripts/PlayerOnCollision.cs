using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerOnCollision : MonoBehaviour
{
    [SerializeField]
    static readonly string GameSave = "ss.json";
    GameObject PlayerCol;
    public static bool p_isDestroyed;
    int deathcountC;
    int deathcountB;
    public static bool is30DEnter = false;
    public static bool isM30DEnter = false;
    public LayerMask whatIs30D;
    public LayerMask whatIsM30D;
    public Transform blockCheckScale;
    float groundRadius = 90;
    public Transform groundCheck;
    public GameObject anima;
    public static Animator anim;
    bool P30DEnter = false;
    bool M30DEnter = false;
    float c=1f;
    GameObject ex;
    GameObject st;
    public static int StarC1;

    void Start()
    {
        PlayerControl.isGroundedAlt=false;
        PlayerControl.isDroppedAlt=false;
        anim = anima.GetComponent<Animator>();
        p_isDestroyed = false;
        anim.SetBool("DeathStart", true);
        if (GameObject.Find("exit") != null)
        {
            ex = GameObject.Find("exit");
            GameObject.Find("exit").SetActive(false);
        }
        if (GameObject.Find("STAR") != null)
        {
            st = GameObject.Find("STAR");
        }
        StarC1=0;
    }

    void FixedUpdate()
    {
        is30DEnter = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIs30D);
        isM30DEnter = Physics2D.OverlapBox(groundCheck.position, blockCheckScale.localScale, groundRadius, whatIsM30D);
    }
    void LNL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        Buttons.isLoad=true;
    }
    void L1L()
    {
        SceneManager.LoadScene("2.2");
        Time.timeScale = 1f;
        Buttons.isLoad=true;
    }
    void LHE()
    {
        SceneManager.LoadScene("GoodEnd");
        Time.timeScale = 1f;
        Buttons.isLoad=true;
    }
    private void cdown()
    {
        c=c-0.1f;
        if (GameObject.Find("BlockPos6").activeSelf)
        GameObject.Find("BlockPos6").GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, c);
        if (c==0f)
        {
            c=1f;
            CancelInvoke("cdown");
        }
    }
    void X6()
    {
        GameObject.Find("BlockPos6").SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "LOADNEXTLEVEL")
        {
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
            anim.SetBool("DeathStart", false);
            Buttons.isExit=true;
            Destroy(GetComponent<Rigidbody2D>());
            p_isDestroyed = true;
            Time.timeScale=1f;
            Invoke("LNL",0.66f);           
        }
        if (other.gameObject.name == "LOADLEVEL1")
        {
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
            anim.SetBool("DeathStart", false);
            Buttons.isExit=true;
            Destroy(GetComponent<Rigidbody2D>());
            p_isDestroyed = true;
            Time.timeScale=1f;
            Invoke("L1L",0.66f);           
        }
        if (other.gameObject.name == "LOADHE")
        {
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
            anim.SetBool("DeathStart", false);
            Buttons.isExit=true;
            Destroy(GetComponent<Rigidbody2D>());
            p_isDestroyed = true;
            Time.timeScale=1f;
            Invoke("LHE",0.66f);  
        }
        if (other.gameObject.name == "LOADCURRENTLEVEL")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            Time.timeScale = 1f;
        }
        if (other.gameObject.tag == "ground")
        {
            PlayerControl.isGroundedAlt=true;
        }
        if (other.gameObject.tag == "drop")
        {
            PlayerControl.isDroppedAlt=true;
        }
        if (other.gameObject.tag == "B1")
        {
            GameObject.Find("BlockPos1").SetActive(false);
        }
        if (other.gameObject.tag == "B2")
        {
            GameObject.Find("BlockPos2").SetActive(false);
        }
        if (other.gameObject.tag == "B3")
        {
            GameObject.Find("BlockPos3").SetActive(false);
        }
        if (other.gameObject.tag == "B4")
        {
            GameObject.Find("BlockPos4").SetActive(false);
        }
        if (other.gameObject.tag == "B5")
        {
            GameObject.Find("BlockPos5").SetActive(false);
        }
        if (other.gameObject.tag == "B6")
        {
            GameObject.Find("BlockPos6").SetActive(false);
        }

        if (other.gameObject.name == "BLACKHOLE")
        {
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
            anim.SetBool("DeathStart", false);
            Buttons.isExit=true;
            Destroy(GetComponent<Rigidbody2D>());
            p_isDestroyed = true;
            Time.timeScale=1f;
            Invoke("LNL",0.66f);  

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

            DDONLOAD.soundData2.Play();
            Invoke("BHDeath",0.66f);
        }
        
        if (other.gameObject.tag == "star")
        {   
            st.SetActive(false);
            ex.SetActive(true);
            StarCollect.CollectStar.Play();
            StarC1+=1;
        }
        
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            PlayerControl.isGroundedAlt=false;
        }
        if (other.gameObject.tag == "drop")
        {
            PlayerControl.isDroppedAlt=false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "spikes")
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
            p_isDestroyed = true;
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
           // InvokeRepeating("Transform", 0f, 0.001f);
            anim.SetBool("DeathStart", false);
            DDONLOAD.soundData2.Play();
            
            Invoke("RestartS", 0.66f);
            
            
        }
        
        if (col.gameObject.name == "spikesG")
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
            p_isDestroyed = true;
            GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
            GetComponentInParent<SpriteRenderer>().color = new Color (1, 1, 1, 0);
           // InvokeRepeating("Transform", 0f, 0.001f);
            anim.SetBool("DeathStart", false);
            DDONLOAD.soundData2.Play();
            
            Invoke("RestartS", 0.66f);
            
            
        }
        if (col.gameObject.name == "menuloadp")
        {
            SceneManager.LoadScene("Menu");
        }
        
    }



    void Update()
    {
        if (isM30DEnter && !M30DEnter)
        {
            Invoke("Flipping1",0f);
            M30DEnter = true;
        }

        if (is30DEnter && !P30DEnter)
        {
            Invoke("Flipping2",0f);
            P30DEnter = true;
        }
        //Exit
        if (M30DEnter && !isM30DEnter)
        {
            Invoke("Flipping2E",0f);
            M30DEnter=false;
        }
        if (P30DEnter && !is30DEnter)
        {
            Invoke("Flipping1E",0f);
            P30DEnter=false;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //anim.SetBool("DeathStart", false);
            
        }
    }
    void Flipping1()
    {
        transform.Rotate(0,0,-30);
    }
    void Flipping2()
    {
        transform.Rotate(0,0,30);
    }
    void Flipping1E()
    {
        transform.Rotate(0,0,-30);
    }
    void Flipping2E()
    {
        transform.Rotate(0,0,30);
    }

    void RestartS()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1f;
    }
    
    void Transform()
    {
       // transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-0.05f, -0.05f, -0.05f), 0.05f);
    }

    void BHDeath()
    {
        Buttons.isLoad=true;
        SceneManager.LoadScene("BHEnd");
    }
}
