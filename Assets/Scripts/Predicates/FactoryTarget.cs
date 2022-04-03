using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestTask
{
    //todo инкапсулировать все поля
    //todo изменить название класса
    
    // разнести на два класса - один хранит и менеджерит target
    // второй управляет логикой проверок
    
    // или же я неверно использую target, а ведь нужно context
    // урок: неправильно назвал переменную, запутался с логикой паттерна
    public class FactoryTarget : IDoubleTarget, IDisposable
    {
        public GameObject targetObject { get; private set; }
        public GameObject toComparer { get; set; }
        public EqualityComparer<GameObject> comparer { get; }
        public int countClick { get; private set; }
        public float timeSinceTheLastClick { get; set; }
        
        public ObjectToCheck toOverlap;

        
        //todo здесь я запутался, логичнее, если toOverlap будет знать о переменной, иначе получается, что эта длинная змия хватает саму себя за хвост
        private bool isDoesntOverlap;

        public FactoryTarget(GameObject target, Descriptions descriptions)
        {
            
            targetObject = target;
            comparer = EqualityComparer<GameObject>.Default;
            toOverlap = new GameObject("For Check").AddComponent<ObjectToCheck>();
            isDoesntOverlap = true;
            

        }

        public void SetTarget(GameObject target)
        {
            targetObject = target;
        }

        public void countPlus()
        {
            countClick++;
        }

        public void Reset()
        {
            countClick = 0;
            timeSinceTheLastClick = 0.0f;
        }

        public void m_IsOverlap()
        {
            isDoesntOverlap = false;
        }

        public void m_IsDoesntOverlap()
        {
            isDoesntOverlap = true;
        }
        
        
        public bool IsOverlap()
        {
            if (targetObject != null)
            {
                Debug.Log($"Мы зашли в метод IsOverlap {toOverlap.OverlapCount}");
            }
            
            return isDoesntOverlap;
        }

        public void Dispose()
        {
            Object.Destroy(targetObject);
            
        }
    }
}