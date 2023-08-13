using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _ps; 
    private bool _isRain = false;  // Флажок идет ли дождь

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>(); //Устанавливаем в поле компонент, на котором скрипт
        _ps.Stop();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if (_isRain && dirLight.intensity > 0.25f)
        {
            LightIntensity(-1);
        } //уменьшение яркости при дожде
        else if (!_isRain && dirLight.intensity < 0.7f)
        {
            LightIntensity(1);
        }// увеличение яркости когда дождь кончился 
    }

    private void LightIntensity(int mult)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * mult;
    }// прибавляем (при mult = -1 вычитаем) освещение 

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(300f, 600f));
            //В промежутке от 300 до 600 сек "меняем погоду"

            if( _isRain )
            {
                _ps.Stop();
            } //Если дождь идет, останавливаем работу парт. систем 
            else
            {
                _ps.Play();
            }

            _isRain = !_isRain; //Переключаем флажок
        }
    }
}
