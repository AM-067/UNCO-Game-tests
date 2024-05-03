using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   public static ObjectPooler current;
   public GameObject PooledGameObject;
   public int PoolAmount;
   public bool WillGrow;

   private List<GameObject> _pooledGameObjects;


   private void Awake()
   {
      current = this;
   }

   private void Start()
   {
      _pooledGameObjects = new List<GameObject>();
      for (int i = 0; i < PoolAmount; i++)
      {
         
         GameObject obj = Instantiate(PooledGameObject);
         obj.SetActive(false);
         _pooledGameObjects.Add(obj);
      }
   }

   public GameObject GetPooledObject()
   {
      for (int i = 0; i < _pooledGameObjects.Count; i++)
      {
         if (!_pooledGameObjects[i].activeInHierarchy)
         {
            return _pooledGameObjects[i];
         }
      }

      if (WillGrow)
      {
         GameObject obj = Instantiate(PooledGameObject);
         _pooledGameObjects.Add(obj);
         return obj;
      }
      return null;
   }
}