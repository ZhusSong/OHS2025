using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Soumen : MonoBehaviour
{
    // ËØE¤ÎÊ¼µE
    public GameObject startPos;

    // ËØE¤Î½KµE
    public GameObject endPos;

    // ËØE¤Î¥â¥Ç¥E
    public GameObject soumen_White;

    public GameObject soumen_Red;

    public GameObject soumen_Green;

    // ¥Á¥§¥Ã¥¯¥İ¥¤¥ó¥È
    public GameObject checkPoint;

    // ¥İ¥¤¥ó¥ÈText
    public TextMeshProUGUI pointNumber;

    // ¥²©`¥à•régText
    public TextMeshProUGUI gameTimeText;
    public Image pointImage;
    public TextMeshProUGUI pointText;

    // ³à¤È¾v¥Ü¥Ã¥¯¥¹Éú³É¤Î´_ÂÊ
    public int random_Red;
    public int random_Green;


    // Ê§”¡¤¹¤EöºÏ•rég¤òÏ÷¤Eı‚
    public int failedTime = 5;

    // ¾vËØE¤ò¥Á¥§¥Ã¥¯¤¹¤EöºÏ•rég¤òÉEÓ¤Eı‚
    public int addTime = 5;


    // ËØE¤È¥Á¥§¥Ã¥¯¥İ¥¤¥ó¥Èég¤Î¾àëx¡£¥¹¥Ú©`¥¹¥Ğ©`¤òÑº¤·¤¿¤È¤­¡¢
    // ËØE¤È¥Á¥§¥Ã¥¯¥İ¥¤¥ó¥Èég¤Î¾àëx¤Ï¤³¤Î‚¤è¤E¡¤µ¤¤ˆöºÏ¡¢ËØE¤¬Ïû¤¨¤E
    public float checkDistance=1.0f;

    // ËØEÉú³É¤Î•régég¸E
    public float intervalTime = 3.0f;

    // ËØE¤ÎÒÆEËÙ¶È
    public float moveSpeed = 1.0f;

    // ²Ğ¤ê•rég
    public float gameTime = 60.0f;

    private int point = 0;

    private List<GameObject> soumenList_White = new List<GameObject>();
    private List<GameObject> soumenList_Red= new List<GameObject>();
    private List<GameObject> soumenList_Green = new List<GameObject>();

    private float deltaTime = 0.0f;
    private float deltaTime_Reduce = 0.0f;
    private bool gameOver = false;
    //private bool Createintarval = false;
    private int CreateCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        CreateNewSoumen();
        pointImage.gameObject.SetActive(false) ;
}

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            deltaTime += Time.deltaTime; 
            deltaTime_Reduce += Time.deltaTime;
            if (deltaTime_Reduce >= 0.01f)
            {
                gameTime -= 0.01f;
                deltaTime_Reduce = 0;
            }

            if (gameTime<=0.0f)
            {
                GameOver();
            }

            if (gameTime >= 60.0f)
            {
                gameTime = 60.0f;
            }
            if(gameTime<=0.0f)
            {
                gameTime = 0.0f;
            }
            if(gameTime<=10.0f)
            {
                gameTimeText.color = Color.red;
            }
            
            //if (Createintarval == false)
            //{
            //    CreateNewSoumen();
            //}
            //if (Createintarval == false)
            //{
            //    CreateNewSoumen();
            //    Createintarval = true;
            //}

            for(; CreateCounter <2; CreateCounter++)
            {
                CreateNewSoumen();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckSoumen();
            }

            MoveSoumen();
            gameTimeText.text = gameTime.ToString("#0.00");
        }
    }

    // ËØE¤òÉú³É¤¹¤E
    void CreateNewSoumen()
    {
        int random = Random.Range(0, 100);
        if(random<= random_Red&&random>random_Green)
        {
            GameObject instance = Instantiate(soumen_Red, startPos.transform.position, startPos.transform.rotation);
            soumenList_Red.Add(instance);
        }
        else if(random <= random_Green)
        {
            GameObject instance = Instantiate(soumen_Green, startPos.transform.position, startPos.transform.rotation);
            soumenList_Green.Add(instance);

        }
        else
        {
            GameObject instance = Instantiate(soumen_White, startPos.transform.position, startPos.transform.rotation);
            soumenList_White.Add(instance);
        }
    }

    // ËØE¤ÎÒÆE
    void MoveSoumen()
    {
        int randomS = Random.Range(0, 4);
        if(soumenList_White != null)
        {
          for(int i=0;i< soumenList_White.Count;i++)
            {
                if (soumenList_White[i]!=null)
                {
                    soumenList_White[i].transform.position = Vector3.MoveTowards(soumenList_White[i].transform.position, endPos.transform.position,moveSpeed * Time.deltaTime * 3);
                    if(soumenList_White[i].transform.position==endPos.transform.position)
                    {
                        
                        Destroy(soumenList_White[i]);
                        soumenList_White.RemoveAt(i);
                        gameTime -= failedTime;
                        CreateCounter--;
                        
                    }
                }
            }
        }
        if (soumenList_Red != null)
        {
            for (int i = 0; i < soumenList_Red.Count; i++)
            {
                if (soumenList_Red[i] != null)
                {
                    soumenList_Red[i].transform.position = Vector3.MoveTowards(soumenList_Red[i].transform.position, endPos.transform.position, moveSpeed *Time.deltaTime * 4);
                    if (soumenList_Red[i].transform.position == endPos.transform.position)
                    {
                        Destroy(soumenList_Red[i]);
                        soumenList_Red.RemoveAt(i);
                        gameTime -= failedTime;
                        CreateCounter--;
                    }
                }
            }
        }
        if (soumenList_Green != null)
        {
            for (int i = 0; i < soumenList_Green.Count; i++)
            {
                if (soumenList_Green[i] != null)
                {
                    soumenList_Green[i].transform.position = Vector3.MoveTowards(soumenList_Green[i].transform.position, endPos.transform.position, moveSpeed * Time.deltaTime * 5);
                    
                    if (soumenList_Green[i].transform.position == endPos.transform.position)
                    {
                        Destroy(soumenList_Green[i]);
                        soumenList_Green.RemoveAt(i);
                        gameTime -= failedTime;
                        CreateCounter--;
                    }
                }
            }
        }
    }

    // ¥¹¥Ú©`¥¹¤òÑº¤·•r¡¢ËØE¤¬Ïû¤¨¤E«¤É¤¦¤«¤òÅĞ¶¨¤¹¤E
    void CheckSoumen()
    {
        if (soumenList_White != null)
        {
            for (int i = 0; i < soumenList_White.Count; i++)
            {
                if (soumenList_White[i] != null)
                {
                    if (Vector3.Distance(soumenList_White[i].transform.position, checkPoint.transform.position) <= checkDistance)
                    {
                        point += 10;
                        pointNumber.text = point.ToString();
                        Destroy(soumenList_White[i]);
                        soumenList_White.RemoveAt(i);
                        CreateCounter--;
                    }
                }
            }
        }
        if (soumenList_Red != null)
        {
            for (int i = 0; i < soumenList_Red.Count; i++)
            {
                if (soumenList_Red[i] != null)
                {
                    if (Vector3.Distance(soumenList_Red[i].transform.position, checkPoint.transform.position) <= checkDistance)
                    {
                        point += 50;
                        pointNumber.text = point.ToString();
                        Destroy(soumenList_Red[i]);
                        soumenList_Red.RemoveAt(i);
                        CreateCounter--;
                    }
                }
            }
        }
        if (soumenList_Green != null)
        {
            for (int i = 0; i < soumenList_Green.Count; i++)
            {
                if (soumenList_Green[i] != null)
                {
                    if (Vector3.Distance(soumenList_Green[i].transform.position, checkPoint.transform.position) <= checkDistance)
                    {
                        gameTime += addTime;
                        pointNumber.text = point.ToString();
                        Destroy(soumenList_Green[i]);
                        soumenList_Green.RemoveAt(i);
                        CreateCounter--;
                    }
                }
            }
        }
    }

    void GameOver()
    {
        pointImage.gameObject.SetActive(true);
        gameOver = true;
        pointText.text = point.ToString();

    }
}
