using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class TPCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform Player;
    public Transform PlayerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject ThirdPC;

    public GameObject Savass;

    public CameraStyle currentStyle;

    public enum CameraStyle
    {
        Normal,
        Savas,
    }

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) KameraGecis(CameraStyle.Normal);
        if (Input.GetKeyDown(KeyCode.Alpha2)) KameraGecis(CameraStyle.Savas);
        //orientation
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //playerobj
        if(currentStyle == CameraStyle.Normal)
        {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(inputDir != Vector3.zero)
        
           PlayerObj.forward = Vector3.Slerp(PlayerObj.forward,inputDir.normalized,Time.deltaTime*rotationSpeed);
        }

        else if(currentStyle == CameraStyle.Savas)
        {
        Vector3 dirTocombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
        orientation.forward = dirTocombatLookAt.normalized;

        PlayerObj.forward = dirTocombatLookAt.normalized;

        }
    
    }

    private void KameraGecis(CameraStyle newStyle)
    {
        Savass.SetActive(false);
        ThirdPC.SetActive(false);

        if(newStyle == CameraStyle.Normal) ThirdPC.SetActive(true);
        if(newStyle == CameraStyle.Savas) Savass.SetActive(true);

        currentStyle = newStyle;

    }

}
