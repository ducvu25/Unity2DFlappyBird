using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousecontroller : MonoBehaviour
{
    public static Mousecontroller instance;
    public Vector4 index = new Vector4( -12.6f, 1.5f, -0.6f, -7.5f) ;
    public bool chooseHero;
    private void Awake()
    {
        instance = this; 
    }
    private void Start()
    {
        chooseHero = false;
        Cursor.visible = false; // Ẩn con trỏ chuột
    }
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
        if(transform.GetChild(0).gameObject.activeSelf && transform.position.x < index.x || transform.position.x > index.y || transform.position.y > index.z || transform.position.y < index.w)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if(chooseHero && !transform.GetChild(0).gameObject.activeSelf && !(transform.position.x < index.x || transform.position.x > index.y || transform.position.y > index.z || transform.position.y < index.w))
            transform.GetChild(0).gameObject.SetActive(true);
        //if(chooseHero && )
    }
    public void SetSprite(Sprite hub)
    {
        chooseHero = true;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = hub;
    }
}
