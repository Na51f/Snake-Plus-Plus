using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Mathematics;

namespace Scripts.Snakes
{
    /// <summary>
    /// Class
    /// <c> Snake </c>
    /// Controls a snake in a grid.
    /// <see> https://en.wikipedia.org/wiki/Snake_(video_game_genre) </see>
    /// </summary>
    [Serializable]
    public class Snake
    { 
        [SerializeField] private Color color;
        [SerializeField] private string up;
        [SerializeField] private string down;
        [SerializeField] private string left;
        [SerializeField] private string right;
        
        public Vector2 Position { private get; set; }
        public Vector2 Direction { get; set; }
        public GameObject Head { get; set; }

        private readonly Queue<GameObject> _tail;
        private Vector2 _direction;
        private Dictionary<string, Vector2> _controls;

        /// <summary>
        /// Constructor
        /// <c> Snake() </c>
        /// Creates a new 
        /// </summary>
        public Snake()
        {
            Head = new GameObject();
            Head.transform.position = Position;
            _tail = new Queue<GameObject>();
            SetControls(up, down, left, right); 
            Head.GetComponent<SpriteRenderer>().color = color;
        }

        /// <summary>
        /// Function
        /// <c> Move </c>
        /// Increments the position of the head by the direction.
        /// Moves the last member of the tail to wherever the head was last.
        /// </summary>
        private void Move()
        {
            var toRequeue = _tail.Dequeue();
            _tail.Enqueue(toRequeue);
            var position = Head.transform.position;
            toRequeue.transform.position = position;
            position += (Vector3) _direction;
            Head.transform.position = position;
        }

        /// <summary>
        /// Function
        /// <c> SetControls </c>
        /// Assigns controls of this snake instance to vectors to assign
        /// positions. Assigns one key (as a string) to one vector.
        /// </summary>
        /// <param name="u">Up Key</param>
        /// <param name="d">Down Key</param>
        /// <param name="l">Left Key</param>
        /// <param name="r">Right Key</param>
        private void SetControls(string u, string d, string l, string r)
        {
            _controls = new Dictionary<string, Vector2>
            {
                {u, Vector2.up},
                {d, Vector2.down},
                {l, Vector2.left},
                {r, Vector2.right}
            };
        }

        public void GetInput()
        {
            foreach (var dir in 
                from dir 
                in _controls 
                where Input.GetKeyDown(dir.Key) is true
                let dot = Vector2.Dot(_direction, dir.Value) 
                where math.abs(dot) < 0.5 
                select dir)
            {
                _direction = dir.Value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void Update()
        {
            GetInput();
            Move();
        }
    }
}
