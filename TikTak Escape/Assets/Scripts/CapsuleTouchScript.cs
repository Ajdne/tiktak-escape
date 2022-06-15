using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTouchScript : MonoBehaviour
{
    // 1st ray is for clicking on the capsule
    Ray ray;
    // 2nd ray is for detecting the end of drag
    Ray ray2;
    RaycastHit hit;
    RaycastHit hit2;
 
    bool mousePressed;
    public int power;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 force;

    // ------------ TRAJECTORY ---------------
    // public GameObject trajectoryDot;
    // public GameObject[] trajectoryDots;
    // [SerializeField] private int numberOfDots;
    public LineRenderer lineRend;
    // ---------------------------------------

    private void Start()
    {
        //trajectoryDots = new GameObject[numberOfDots];


        // for (int i = 0; i < numberOfDots; i++)
        //         {
        //             trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
        //         }   
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {          // on mouse click
            
            ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            if (Physics.Raycast (ray, out hit)) {       // if the click hits a target

                //mousePressed = true;  

                startPoint = new Vector3(hit.transform.position.x, hit.transform.position.y, 0);

                // absolute values:
                //startPoint = new Vector3(Mathf.Abs(hit.transform.position.x), Mathf.Abs(hit.transform.position.y), 0);

                print(startPoint);

                lineRend.enabled = true;

                lineRend.SetPosition(0, startPoint);

        // DEBUG PLS
        
                             
            }
        }

        


        //if (mousePressed)   // while the mouse is pressed down
        if (Input.GetMouseButton(0))
        {   
            // detect ray on plain
            ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast (ray2, out hit2))   // hit is basically an object hit by this raycast
            {
                endPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * (-1) ));
                // //endPoint = new Vector3(hit2.transform.position.x, hit2.transform.position.y, 0);
                
                print(endPoint);

                lineRend.SetPosition(1, endPoint);                
            }

            //print(endToCamera);

            

            // for (int i = 0; i < numberOfDots; i++)
            // {
                //trajectoryDots[i].transform.position = calculatePosition(i * 0.1f);
                //Instantiate(trajectoryDot, trajectoryDots[i].transform);
                 //Instantiate(trajectoryDot, trajectoryDots[i].transform);
            // }

            // for (int i = 0; i < numberOfDots; i++)
            //     {
            //         trajectoryDots[i] = Instantiate(trajectoryDot, trajectoryDots[i].transform);
            //     }  
        }

        force = (startPoint - endPoint) * power;

        if (Input.GetMouseButtonUp(0)) {            // on mouse release

            //mousePressed = false;

            hit.rigidbody.AddForce(force);

            GameManager.Instance.numberOfMoves -- ;
            UIManager.Instance.UpdateMovesUI();

            lineRend.enabled = false;
            // remove the trajectory dots
            // for (int i = 0; i < numberOfDots; i++)
            // {
            //     Destroy(trajectoryDots[i]);
            // }
        }




        // if no moves left
        if(!GameManager.Instance.HasMoves())    
        {
            //print("Looser!");
        }
    }


    // attempt to calculate object trajectory
    private Vector2 calculatePosition(float elapsedTime)
    {
        return (new Vector2(endPoint.x, endPoint.y) + //X0
                new Vector2(-force.x, -force.y) * elapsedTime + //ut
                0.5f * Physics2D.gravity * elapsedTime * elapsedTime);
    }

}
