using Fungus;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soumen : MonoBehaviour
{
    // ���M��ʼ��
    public GameObject startPos;

    // ���M�νK��
    public GameObject endPos;

    // ���M�Υ�ǥ�
    public GameObject soumen;

    // �����å��ݥ����
    public GameObject checkPoint;

    // ���M�ȥ����å��ݥ�����g�ξ��x�����ک`���Щ`��Ѻ�����Ȥ���
    // ���M�ȥ����å��ݥ�����g�ξ��x�Ϥ��΂����С�������ϡ����M��������
    public float checkDistance=1.0f;

    // ���M���ɤΕr�g�g��
    public float intervalTime = 3.0f;

    // ���M���Ƅ��ٶ�
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

    // ���M�����ɤ���
    void CreateNewSoumen()
    {
        GameObject instance = Instantiate(soumen, startPos.transform.position, startPos.transform.rotation);
        soumenList.Add(instance);
    }

    // ���M���Ƅ�
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

    // ���ک`����Ѻ���r�����M�������뤫�ɤ������ж�����
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
