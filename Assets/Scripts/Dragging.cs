using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    [SerializeField]
    private Transform Pos1;
    private Vector2 mousePosition;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(!locked)
        {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }
    }
    private void OnMouseDrag()
    {
        if(!locked)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
        }
    }
    private void OnMouseUp()
    {
        if (Mathf.Abs(transform.position.x - Pos1.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - Pos1.position.y) <= 0.5f)
        {
            transform.position = new Vector2(Pos1.position.x, Pos1.position.y);
            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        }
    }
}
