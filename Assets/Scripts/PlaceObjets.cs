using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjets : MonoBehaviour
{

    public LayerMask layer; //поверхность с которой работаем
    public float rotateSpeed = 60f; //скорость поворота дома

    private void Start()
    {
        PositionObject();
    }

    private void PositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //отслеживаем куда от мышки падает луч на нашу карту
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        // 1000 - длинна луча
        {
            transform.position = hit.point; //место попадани€ луча
        }
    }

    private void Update()
    {
        PositionObject();

        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.GetComponent<AutoCarCreate>())
            gameObject.GetComponent<AutoCarCreate>().enabled = true;
            // активаци€ скрипта создающего машины 
            Destroy(gameObject.GetComponent<PlaceObjets>());
        } // ѕи нажатии на ѕкћ удал€ет этот скрипт с объекта?  
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        } //поворот дома
    }
}
