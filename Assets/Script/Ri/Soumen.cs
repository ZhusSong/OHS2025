using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soumen : MonoBehaviour
{
    // 素麺の始点
    public GameObject startPos;

    // 素麺の終点
    public GameObject endPos;

    // 素麺のモデル
    public GameObject soumen;

    // チェックポイント
    public GameObject checkPoint;

    // 素麺とチェックポイント間の距離。スペースバーを押したとき、
    // 素麺とチェックポイント間の距離はこの値より小さい場合、素麺が消える
    public float checkDistance=1.0f;

    // 素麺生成の時間間隔
    public float intervalTime = 3.0f;

    // 素麺の移動速度
    public float moveSpeed = 1.0f;

    private List<GameObject> soumenList = new List<GameObject>();

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
        GameObject instance = Instantiate(soumen, startPos.transform.position, startPos.transform.rotation);
        soumenList.Add(instance);
    }

    // 素麺の移動
    void MoveSoumen()
    {
        if(soumenList!=null)
        {
          for(int i=0;i<soumenList.Count;i++)
            {
                if (soumenList[i]!=null)
                {
                    soumenList[i].transform.position = Vector3.MoveTowards(soumenList[i].transform.position, endPos.transform.position,moveSpeed*Time.deltaTime);
                    if(soumenList[i].transform.position==endPos.transform.position)
                    {
                        Destroy(soumenList[i]);
                        soumenList.RemoveAt(i);
                    }
                }
            }
        }
    }

    // スペースを押し時、素麺が消えるかどうかを判定する
    void CheckSoumen()
    {
        if (soumenList != null)
        {
            for (int i = 0; i < soumenList.Count; i++)
            {
                if (soumenList[i] != null)
                {
                    if (Vector3.Distance(soumenList[i].transform.position, checkPoint.transform.position) <= checkDistance)
                    {
                        Destroy(soumenList[i]);
                        soumenList.RemoveAt(i);
                    }
                }
            }
        }
    }
}
