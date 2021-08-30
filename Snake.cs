using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public bool ate = false;
    public GameObject tailPrefab;
    Vector2 dir = Vector2.right;
    public List<Transform> tail = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
       // TestAny();
    }

    // Update is called once per frame
    void Update()
    {
        Move_Arrows();
    }

    private void Move()
    {
        
        Vector2 v = transform.position;
        transform.Translate(dir);

        if (ate)
        {
            //GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if(tail.Count > 0)
        {
           tail.Last().position = v;
           tail.Insert(0, tail.Last());
           tail.RemoveAt(tail.Count - 1);
        }
    }
    void Move_Arrows()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.name.StartsWith("food"))
        {
            ate = true;
            Destroy(coll.gameObject);
        }
        else
        {
            Debug.Log("no food");
        }
    }



    void TestAny()
    {
        List<string> li_string = new List<string>();
        li_string.Add("string1");
        li_string.Add("says");
        li_string.Add("Hello");
        foreach(string temp in li_string)
        {
            Debug.Log(temp);
        }
        Debug.Log(li_string.Count);
        Debug.Log(li_string.Contains("says"));
        //Debug.Log( li_string.LastIndexOf(li_string));
        //li_string.Last().
    }

    
}
