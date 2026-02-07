using UnityEngine;
using UnityEngine.UI;

public class SliderLive : MonoBehaviour
{
    public Slider slider;

    void Start(){
        
    }

    public void setMaxSalud(float max){
        slider.maxValue = max;
        slider.maxValue = max;
    }

    public void setSalud(float salud){
        slider.value = salud;
    }
}
