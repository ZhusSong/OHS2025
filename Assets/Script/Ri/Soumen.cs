using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Soumen : MonoBehaviour
{
    // 素麺の始点
    public GameObject startPos;

    // 素麺の終点
    public GameObject endPos;

    // 素麺のモデル
    public GameObject soumen_White;

    public GameObject soumen_Red;

    public GameObject soumen_Green;

    // チェックポイント
    public GameObject checkPoint;

    // ポイントText
    public TextMeshProUGUI pointNumber;

    // ゲーム時間Text
    public TextMeshProUGUI gameTimeText;
    public Image pointImage;
    public TextMeshProUGUI pointText;

    // 赤と緑ボックス生成の確率
    public int random_Red;
    public int random_Green;


    // 失敗する場合時間を削る数値
    public int failedTime = 5;

    // 緑素麺をチェックする場合時間を伸びる数値
    public int addTime = 5;


    // 素麺とチェックポイント間の距離。スペースバーを押したとき、
    // 素麺とチェックポイント間の距離はこの値より小さい場合、素麺が消える
    public float checkDistance=1.0f;

    // 素麺生成の時間間隔
    public float intervalTime = 3.0f;

    // 素麺の移動速度
    public float moveSpeed = 1.0f;

    // 残り時間
    public float gameTime = 60.0f;

    private int point = 0;

    private List<GameObject> soumenList_White = new List<GameObject>();
    private List<GameObject> soumenList_Red= new List<GameObject>();
    private List<GameObject> soumenList_Green = new List<GameObject>();

    private float deltaTime = 0.0f;
    private float deltaTime_Reduce = 0.0f;
    private bool gameOver = false;
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

            if (deltaTime >= intervalTime)
            {
                CreateNewSoumen();
                deltaTime = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CheckSoumen();
            }

            MoveSoumen();
            gameTimeText.text = gameTime.ToString("#0.00");
        }
    }

    // 素麺を生成する
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

    // 素麺の移動
    void MoveSoumen()
    {
        if(soumenList_White != null)
        {
          for(int i=0;i< soumenList_White.Count;i++)
            {
                if (soumenList_White[i]!=null)
                {
                    soumenList_White[i].transform.position = Vector3.MoveTowards(soumenList_White[i].transform.position, endPos.transform.position,moveSpeed*Time.deltaTime);
                    if(soumenList_White[i].transform.position==endPos.transform.position)
                    {
                        Destroy(soumenList_White[i]);
                        soumenList_White.RemoveAt(i);
                        gameTime -= failedTime;
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
                    soumenList_Red[i].transform.position = Vector3.MoveTowards(soumenList_Red[i].transform.position, endPos.transform.position, moveSpeed * Time.deltaTime);
                    if (soumenList_Red[i].transform.position == endPos.transform.position)
                    {
                        Destroy(soumenList_Red[i]);
                        soumenList_Red.RemoveAt(i);
                        gameTime -= failedTime;
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
                    soumenList_Green[i].transform.position = Vector3.MoveTowards(soumenList_Green[i].transform.position, endPos.transform.position, moveSpeed * Time.deltaTime);
                    if (soumenList_Green[i].transform.position == endPos.transform.position)
                    {
                        Destroy(soumenList_Green[i]);
                        soumenList_Green.RemoveAt(i);
                        gameTime -= failedTime;
                    }
                }
            }
        }
    }

    // スペースを押し時、素麺が消えるかどうかを判定する
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
