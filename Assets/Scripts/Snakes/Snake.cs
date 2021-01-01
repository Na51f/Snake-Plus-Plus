using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Snakes
{
    [System.Serializable]
    public class Snake : MonoBehaviour
    {
        public Color color;
        public Vector2 CurrentDirection { private get; set; }

        private readonly GameObject _head;
        private readonly Queue<GameObject> _tail;
        private Dictionary<string, Vector2> _controls;

        public Snake(GameObject head, string u, string d, string l, string r)
        {
            _head = head;
            _tail = new Queue<GameObject>();
            SetControls(u, d, l, r);
        }

        public void Awake()
        {
            var sr = _head.GetComponent<SpriteRenderer>();
            sr.color = color;
        }
        
        public void Move()
        {
            var toRequeue = _tail.Dequeue();
            _tail.Enqueue(toRequeue);
            var position = _head.transform.position;
            toRequeue.transform.position = position;
            position += (Vector3) CurrentDirection;
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
    }
}