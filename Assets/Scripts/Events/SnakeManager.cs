using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.Snakes;
using UnityEngine;

namespace Scripts.Events
{
    /// <summary>
    /// Class
    /// <c> SnakeManager</c>
    /// Controls the list of snakes (players or AIs)
    /// </summary>
    [ExecuteInEditMode]
    public class SnakeManager : MonoBehaviour
    {
        public GameObject SnakePrefab { get; set; }
        [SerializeField] private List<Snake> snakeList;

        private int _snakeCount = 0;

        /// <summary>
        /// Event Function
        /// <c> Awake </c>
        /// Instantiates snake list.
        /// Starts coroutine to check and manage newly added snakes.
        /// </summary>
        public void Awake()
        {
            snakeList = new List<Snake>();
            StartCoroutine(NewSnakeCheck());
        }

        // TODO Docs
        
        public void Update()
        {
            _snakeCount = snakeList.Count;
        }

        IEnumerator NewSnakeCheck()
        {
            yield return new WaitUntil(() => _snakeCount != snakeList.Count);
        }
    }
}
