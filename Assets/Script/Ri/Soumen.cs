using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Soumen : MonoBehaviour
{
    // 素麺の始点
    public GameObject startPos;

    // 素麺の終点
    public GameObject endPos;

    // 素麺のモデル
    public GameObject soumen_White;

    public GameObject soumen_Red;

    // チェックポイント
    public GameObject checkPoint;

    // ポイントText
    public TextMeshProUGUI pointNumber;

    // 赤いボックス生成の確率
    public int redRandom;

    // 素麺とチェックポイント間の距離。スペースバーを押したとき、
    // 素麺とチェックポイント間の距離はこの値より小さい場合、素麺が消える
    public float checkDistance=1.0f;

    // 素麺生成の時間間隔
    public float intervalTime = 3.0f;

    // 素麺の移動速度
    public float moveSpeed = 1.0f;

    private int point = 0;

    private List<GameObject> soumenList_White = new List<GameObject>();
    private List<GameObject> soumenList_Red= new List<GameObject>();

    private float deltaTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        CreateNewSoumen();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= intervalTime)
        {
            CreateNewSoumen();
            deltaTime = 0;
        }
        MoveSoumen();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSoumen();
        }
    }

    // 素麺を生成する
    void CreateNewSoumen()
    {
        int random = Random.Range(0, 100);
        if(random<=redRandom)
        {
            GameObject instance = Instantiate(soumen_Red, startPos.transform.position, startPos.transform.rotation);
            soumenList_Red.Add(instance);
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
    }
}
