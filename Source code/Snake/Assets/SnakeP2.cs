using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeP2 : MonoBehaviour {
    //moves to the right (default)
    Vector2 dir = Vector2.left;
    

    //tail of the snake
    List<Transform> tail = new List<Transform>();

    //did the snake eat? (Default on false so that it's not eating from the start
    bool ate = false;

    //tail prefab
    public GameObject tailPrefab;

    private int count;
    public Text countText;

    private Vector2 x1 = Vector2.left;
    private Vector2 x2 = Vector2.right;
    private Vector2 y1 = Vector2.up;
    private Vector2 y2 = Vector2.down;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("Move", 0.9f, 0.05f);
        count = 0;
        countText.text = "Player 2 Score: " + count.ToString();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow) & !dir.Equals(y2))
            dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow) & !dir.Equals(y1))
            dir = Vector2.down;
        else if (Input.GetKey(KeyCode.LeftArrow) & !dir.Equals(x2))
            dir = Vector2.left;
        else if (Input.GetKey(KeyCode.RightArrow) & !dir.Equals(x1))
            dir = Vector2.right;
    }

    //Movement of the snake
    void Move() {
        //current position save
        Vector2 v = transform.position;

        //moves the snake head in a new direction
        transform.Translate(dir);

        //if ate, insert a new tail block in the gap
        if (ate) {
            //load prefab
            GameObject g = (GameObject)Instantiate(tailPrefab,
                                                   v,
                                                   Quaternion.identity);

            //keep track in the tail list
            tail.Insert(0, g.transform);

            //Reset the flag
            ate = false;
        }

        //checks if the snake has a tail
        else if (tail.Count > 0) {
            //the last position goes to where the head used to be
            tail.Last().position = v;

            //add the last piece of the tail to the front and delete it from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name.StartsWith("FoodPrefab")) {
            //gets longer in next move()
            ate = true;

            //destroy the eaten food
            Destroy(collision.gameObject);
            count += 1;
            countText.text = "Player 2 Score: " + count.ToString();

        } else if (collision.name.StartsWith("BorderTop") |
                   collision.name.StartsWith("BorderBottom") |
                   collision.name.StartsWith("BorderLeft") |
                   collision.name.StartsWith("BorderRight") |
                   collision.name.StartsWith("Tail")) {
            //Todo Game Over screen
            SceneManager.LoadScene(1);
        } else if (collision.name.StartsWith("Player")) {
            SceneManager.LoadScene(2);
        }
    }
}
