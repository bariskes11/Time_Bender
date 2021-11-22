using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PoolDictionary : MonoBehaviour
    {
        //game objects queue
        [HideInInspector]
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        private List<Pool> _pool;
        public void ResetPool()
        {
            _pool = new List<Pool>();

        }
        // starts objectpool
        public void setPool(List<Pool> pool, Transform parent)
        {
            _pool = pool;
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            foreach (Pool item in _pool)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < item.size; i++)
                {
                    GameObject gmObj = Instantiate(item.prefab);
                    gmObj.SetActive(false);
                    //  gmObj.transform.SetParent(parent);
                    objectPool.Enqueue(gmObj);
                }
                poolDictionary.Add(item.tag, objectPool);
            }

        }
        private void activateAllChildren(GameObject gm)
        {
            gm.SetActive(true);
            for (int j = 0; j < gm.transform.childCount; j++)
            {
                gm.transform.GetChild(j).gameObject.SetActive(true);
            }

        }

        // calls object from pool
        public GameObject SpawnFromPool(string tag, Vector3 position, Transform parent)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.Log("Obj tag is not Found:" + tag);
                return null;
            }
            GameObject spawnObj = poolDictionary[tag].Dequeue();
            //makes selected gameobject active
            activateAllChildren(spawnObj);
            if (parent != null)
            {
                spawnObj.transform.SetParent(parent);
            }
            else
            {
                //  transform.SetParent(parent);
            }
            spawnObj.transform.position = position;
            spawnObj.transform.rotation = Quaternion.identity;

            poolDictionary[tag].Enqueue(spawnObj);
            return spawnObj;


        }



    }
