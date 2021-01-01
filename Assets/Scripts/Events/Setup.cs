using System;
using System.Collections.Generic;
using Scripts.Snakes;
using UnityEngine;

namespace Scripts.Events
{
    [ExecuteInEditMode]
    public class Setup : MonoBehaviour
    {
        [SerializeField] private List<Snake> snakeList;
        [SerializeField] private GameObject snakePrefab;

        public void Awake()
        {
            snakeList = new List<Snake>();
        }
    }
}
