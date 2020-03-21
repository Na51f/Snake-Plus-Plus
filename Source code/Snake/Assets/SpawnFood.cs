using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
    
    //food prefab
    public GameObject foodPrefab;

    //borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    //spawns one piece of food
    void Start() {
        InvokeRepeating("Spawn", 3, 4);
    }
   
    //spawns the food within
    void Spawn() {
        //random x position for food between the left and right borders
        int x = (int)Random.Range(borderLeft.position.x,
                                  borderRight.position.x);

        //random y position for food between the top and bottom borders
        int y = (int)Random.Range(borderTop.position.y, 
                                  borderBottom.position.y);

        //instantiating the positioning
        Instantiate(foodPrefab, 
                    new Vector2(x, y), 
                    Quaternion.identity);

    }

    
}
