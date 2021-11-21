using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    //Klicka i FreeView i inpectorn. Sen ?r det bara att anv?nda WASD och musen f?r att styra kameran


    // Start is called before the first frame update
    void Start()
    {
        //anv?nds f?r kontroll
        characterController = GetComponent<CharacterController>();
    }
    Vector3 Angles;
    public float sensitivityX;
    public float sensitivityY;
    public GameObject cameraMan;
    public CharacterController characterController;
    public float movementSpeed;
    public bool freeView = false; //variabel f?r att st?nga av och p? MousecameraMovement
    public Text myText;

    public float rotationY = -0.25f;
    public float rotationX = 0;

    //************Camera Zoom*************//

    public float ScrollSpeed = 15;
    public float zoomChangeAmount = 60;
    public float minZoom = 2;
    public float maxZoom = 140;
    
    //**************************************//


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 15;
        }
        else
        {
            movementSpeed = 5;
        }
        if (Input.GetKeyDown("space"))
        {
            freeView = !freeView;
        }
        //H?mta positionen f?r musen
       
        if (freeView) //Vi vill inte att musen st?r hela tiden
        {
            rotationY = Input.GetAxis("Mouse Y") * sensitivityX;
            rotationX = Input.GetAxis("Mouse X") * sensitivityY;
            myText.text = "Press space to disable Mouseview";
            if (rotationY > 0)
            {
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, -80, rotationY), Angles.y + rotationX, 0);
            }
            else
            {
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, 80, -rotationY), Angles.y + rotationX, 0);
            }

            //sk?ter s? att kameran r?r sig med musen

        }
        else { myText.text = "Press space to enable Mouseview"; }
       
            cameraMan.transform.localEulerAngles = Angles;

            //Kontroller f?r WASD
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed;
            float vertical = Input.GetAxis("Vertical") * movementSpeed;


            Vector3 moveDirectionForward = transform.forward * vertical;
            Vector3 moveDirectionSide = transform.right * horizontal;

            //Hittar vart vi tittar
            Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
            //Hittar hur "l?ngt" vi ska g?
            Vector3 distance = direction * movementSpeed * Time.deltaTime;
           
            //L?ser kameran i y-led
            Vector3 OnlyZX = new Vector3(1, 0, 1);
            // Apply Movement to Player
            characterController.Move(Vector3.Scale(distance, OnlyZX));

        //*******************************************************Camera Zoom*********************************************************//
        if (Input.mouseScrollDelta.y > 0)
        {
            GetComponent<Camera>().fieldOfView -= zoomChangeAmount * Time.deltaTime * ScrollSpeed;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            GetComponent<Camera>().fieldOfView += zoomChangeAmount * Time.deltaTime * ScrollSpeed;
        }

        GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, minZoom, maxZoom);
        //***************************************************************************************************************************//
    }
}

