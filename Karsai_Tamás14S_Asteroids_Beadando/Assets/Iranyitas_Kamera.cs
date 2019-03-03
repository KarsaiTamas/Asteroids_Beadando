using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iranyitas_Kamera : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;
    //public AudioSource audio;
    List<GameObject> aszteroidak = new List<GameObject>();
   
    void Start()
    {
       
        System.Random rnd =new System.Random();
        
        var kamera = GameObject.FindGameObjectWithTag("MainCamera");
        var urhajo = GameObject.FindGameObjectWithTag("player");
        rb2d = GetComponent<Rigidbody2D>();
        offset = kamera.transform.position - urhajo.transform.position;
        
        
        for (int i = 0; i < 15; i++)
        {
            var prefab = Resources.Load<GameObject>("aszteroida"+ (i%3+1));
            var obj = Instantiate<GameObject>(prefab);
            obj.transform.Translate(new Vector2((float)(rnd.NextDouble()*5-2.5), (float)(rnd.NextDouble() * 5 - 2.5)));
            aszteroidak.Add(obj);
            
        }

    }
    float urhajo_sebessege=0;
    float max_sebesseg = 8;
    private Rigidbody2D rb2d;
    float gyorsit;
    float balra_fordulas;
    float jobbra_fodulas;
    float lassitas;
    
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var urhajo = GameObject.FindGameObjectWithTag("player");
        if (collision.gameObject.tag== "aszteroida")
        {/*
            urhajo_sebessege = 0;
            gyorsit = 0;
            balra_fordulas = 0;
            jobbra_fodulas = 0;
            lassitas = 0;
            */
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        var urhajo = GameObject.FindGameObjectWithTag("player");

        if (collision.gameObject.tag == "aszteroida")
        {
            
        }
    }
    void FixedUpdate()
    {
        var kamera = GameObject.FindGameObjectWithTag("MainCamera");
        var urhajo = GameObject.FindGameObjectWithTag("player");
         
        gyorsit = Input.GetAxis("Gyorsitas");
        lassitas = Input.GetAxis("Lassitas");

        Vector2 movement;
        
        movement = new Vector2(0, gyorsit);
        rb2d.AddForce(movement * gyorsit);

        movement = new Vector2(0, lassitas+1);
        rb2d.AddForce(movement * lassitas);
        //rb2d.AddForce(movement * lassitas);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // if(max_sebesseg< urhajo_sebessege)
            // { 
            urhajo_sebessege += gyorsit / 10;
            if (urhajo_sebessege>max_sebesseg)
            {
                urhajo_sebessege = max_sebesseg;

               // rb2d.velocity = transform.up * urhajo_sebessege;
            }
           
              
                rb2d.velocity = urhajo.transform.up * urhajo_sebessege;
            kamera.transform.position = urhajo.transform.position+offset;
            


            //  }

            // 
        }
        else
        {
            
            if (urhajo_sebessege>0)
            {
                urhajo_sebessege = urhajo_sebessege - 0.005f;
                rb2d.velocity = rb2d.velocity/1.001f;

                kamera.transform.position = urhajo.transform.position + offset;
            }
        }
        
        


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            
            if (max_sebesseg*-1 < urhajo_sebessege)
            {
                urhajo_sebessege += lassitas / 10;
              //  urhajo_sebessege = max_sebesseg * -1;
                
            }
            
               
                rb2d.velocity = urhajo.transform.up * urhajo_sebessege;

            kamera.transform.position = urhajo.transform.position + offset;
        }
        else
        {
            if (urhajo_sebessege < 0)
            {
            urhajo_sebessege = urhajo_sebessege + 0.005f;
            rb2d.velocity = urhajo.transform.up * urhajo_sebessege;

                kamera.transform.position = urhajo.transform.position + offset;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            urhajo.transform.Rotate(Vector3.forward*+2);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            urhajo.transform.Rotate(Vector3.forward * -2);
        }

     

        if (urhajo.transform.position.y>3.5)
        {
            urhajo.transform.position = new Vector2(urhajo.transform.position.x, -3.5f);

            kamera.transform.position = urhajo.transform.position + offset;
        }
        if (urhajo.transform.position.y < -3.5)
        {
            urhajo.transform.position = new Vector2(urhajo.transform.position.x, 3.5f);

            kamera.transform.position = urhajo.transform.position + offset;
        }
        if (urhajo.transform.position.x > 3.5)
        {
            urhajo.transform.position = new Vector2(-3.5f, urhajo.transform.position.y);

            kamera.transform.position = urhajo.transform.position + offset;
        }
        if (urhajo.transform.position.x < -3.5)
        {
            urhajo.transform.position = new Vector2(3.5f, urhajo.transform.position.y);

            kamera.transform.position = urhajo.transform.position + offset;
        }

        foreach (var item in aszteroidak)
        {

        if (item.transform.position.y > 4.5)
        {
            item.transform.position = new Vector2(item.transform.position.x, -4.5f);


        }
        if (item.transform.position.y < -4.5)
        {
            item.transform.position = new Vector2(item.transform.position.x, 4.5f);

        
        }
        if (item.transform.position.x > 4.5)
        {
            item.transform.position = new Vector2(-4.5f, item.transform.position.y);

        
        }
        if (item.transform.position.x < -4.5)
        {
            item.transform.position = new Vector2(4.5f, item.transform.position.y);

        }
        }

    }
}
