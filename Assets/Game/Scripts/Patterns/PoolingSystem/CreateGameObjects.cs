
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateGameObjects : MonoBehaviour
{
    public Transform Parent;

    [SerializeField]
    public List<Pool> gameObjectList;
    private PoolDictionary poolDic;
    [SerializeField]
    private List<GameObject> gmSelectedGameObjects;
    private Transform destinatinTransform;
    private static CreateGameObjects _instance;
    public static CreateGameObjects Instance { get { return _instance; } }
  


    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        StartPooling();
    }
    public void StartPooling()
    {
        destinatinTransform = this.GetComponent<Transform>();
        poolDic = GetComponent<PoolDictionary>();
        poolDic.ResetPool();
        poolDic.setPool(gameObjectList, Parent);
    }

    public GameObject CreateGameObject(string TagName, Vector3 pos, Transform parent)
    {
        return poolDic.SpawnFromPool(TagName, pos, parent);
    }
    public GameObject InstantiateObject(string TagName, Vector3 pos)
    {
        Pool item = gameObjectList.Where(x => x.tag == TagName).FirstOrDefault();
        if (item != null)
        {
            return Instantiate(item.prefab, pos, Quaternion.identity);
        }
        return null;

    }

    public int AddOnScreenSelectedGameObject(GameObject gmObj)
    {
        gmSelectedGameObjects.Add(gmObj);
        return gmSelectedGameObjects.IndexOf(gmObj); // last insterted index
    }
    public void RemoveOnScreenSelectedGameObject()
    {
        gmSelectedGameObjects.Clear();

    }


}
