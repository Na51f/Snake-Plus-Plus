using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Snakes
{
    /// <summary>
    /// Class
    /// <c> SnakeManager </c>
    /// Keeps tracks of all controls of the snakes.
    /// Manages movement of the snakes every frame.
    /// </summary>
    [Serializable]
    public class SnakeManager
    {
        private readonly List<Snake> _snakeList;

        /// <summary>
        /// Constructor
        /// <c> SnakeManager(List<Snake/>) </c>
        /// Adds reference to the list in setup to this class.
        /// </summary>
        /// <param name="snakeList">
        /// The list of snakes from the setup class.
        /// </param>
        public SnakeManager(List<Snake> snakeList)
        {
            _snakeList = snakeList;
        }

        /// <summary>
        /// Function
        /// <c> Update </c>
        /// Called on every frame while Setup.cs is running.
        /// </summary>
        public void Update()
        {
            foreach (var snake in _snakeList)
            {
                snake.Update();
            }
        }
    }
}