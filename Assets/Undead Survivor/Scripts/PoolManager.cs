using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //��������� ������ ����
    public GameObject[] prefabs;


    //Ǯ ����� �ϴ� ����Ʈ �ʿ�
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        //������ Ǯ�� ��� �ִ�(��Ȱ��ȭ��) ���� ������Ʈ ����
        foreach(GameObject item in pools[index])
        {
            if (!item.activeSelf)
            { //�߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        //�� ã������ ���Ӱ� �����ϰ� select ������ �Ҵ�
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}