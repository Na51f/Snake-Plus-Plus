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

        private readonly GameObject _head;
        private readonly Queue<GameObject> _tail;
        private Dictionary<string, Vector2> _controls;
        private Vector2 _direction;

        public Snake(GameObject head, string u, string d, string l, string r)
        {
            _head = head;
            _tail = new Queue<GameObject>();
            var x = head.transform.position.x;
            _direction = new Vector2(math.round(x / math.abs(x)), 0);
            SetControls(u, d, l, r);
        }

        private void Move()
        {
            var toRequeue = _tail.Dequeue();
            _tail.Enqueue(toRequeue);
            var position = _head.transform.position;
            toRequeue.transform.position = position;
            position += (Vector3) _direction;
            _head.transform.position = position;
        }

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

        private void GetInput()
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

        public void Awake()
        {
            var sr = _head.GetComponent<SpriteRenderer>();
            sr.color = color;
        }

        public void Update()
        {
            GetInput();
            Move();
        }
    }
}
