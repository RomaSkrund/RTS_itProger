using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    float rotateSpeed = 40.0f; //Скорость поворота
    float moveSpeed = 25.0f; //Скорость движения камеры 
    float zoomSpeed = 15.0f; //Скорость подъема и спуска камеры 

    float coefMult = 1f; //коэф. на который умножается скороть (удваиваетсья при зажатии LShift)

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //клавиши отвечающие за гор. передвижение 
        float vertical = Input.GetAxis("Vertical"); ////клавиши отвечающие за вер. передвижение

        float rotateDirection = 0f; //Направление поворота камеры
        if (Input.GetKey(KeyCode.Q))
        {
            rotateDirection = -1f; //Поворот влево
        }
        else if (Input.GetKey(KeyCode.E)) 
        {
            rotateDirection = 1f; //поворот вправо
        }

        coefMult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1; 

        transform.Rotate(Vector3.up * rotateSpeed *
            Time.deltaTime * rotateDirection * coefMult, Space.World);
        // Поворот камеры: координату Y (Vector3.up) умножаем на скорость поворота,
        // дельтаТайм (плавность), направление поворота и коэф. ускорения
        // вращаем относительно глобальных координат (Space.World)

        transform.Translate(new Vector3(horizontal, 0, vertical) * 
            Time.deltaTime * coefMult * moveSpeed, Space.Self);
        // Движение объекта

        transform.position += transform.up * zoomSpeed *
            Input.GetAxis("Mouse ScrollWheel");
        // Приближение и отдаление камеры

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -25f, 25f),
            transform.position.z);
        // Ограничения приближения и тдаления камеры

    }
}
