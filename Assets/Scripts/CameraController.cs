using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float rotateSpeed = 40.0f; //�������� ��������
    float moveSpeed = 25.0f; //�������� �������� ������ 
    float zoomSpeed = 15.0f; //�������� ������� � ������ ������ 

    float coefMult = 1f; //����. �� ������� ���������� ������� (������������ ��� ������� LShift)

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //������� ���������� �� ���. ������������ 
        float vertical = Input.GetAxis("Vertical"); ////������� ���������� �� ���. ������������

        float rotateDirection = 0f; //����������� �������� ������
        if (Input.GetKey(KeyCode.Q))
        {
            rotateDirection = -1f; //������� �����
        }
        else if (Input.GetKey(KeyCode.E)) 
        {
            rotateDirection = 1f; //������� ������
        }

        coefMult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1; 

        transform.Rotate(Vector3.up * rotateSpeed *
            Time.deltaTime * rotateDirection * coefMult, Space.World);
        // ������� ������: ���������� Y (Vector3.up) �������� �� �������� ��������,
        // ���������� (���������), ����������� �������� � ����. ���������
        // ������� ������������ ���������� ��������� (Space.World)

        transform.Translate(new Vector3(horizontal, 0, vertical) * 
            Time.deltaTime * coefMult * moveSpeed, Space.Self);
        // �������� �������

        transform.position += transform.up * zoomSpeed *
            Input.GetAxis("Mouse ScrollWheel");
        // ����������� � ��������� ������

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -25f, 25f),
            transform.position.z);
        // ����������� ����������� � �������� ������

    }
}
