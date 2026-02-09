using UnityEngine;
using UnityEngine.UI;

public class LifeSlider1 : MonoBehaviour
{
    private Slider _slider;

    void Start(){
        _slider = GetComponent<Slider>();
    }

    public void setMaxLife(float max){
        _slider.maxValue = max;
        _slider.value = max;
    }

    public void setLife(float life){
        _slider.value = life;
    }
}
