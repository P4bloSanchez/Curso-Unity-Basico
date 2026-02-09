using UnityEngine;
using UnityEngine.UI; 

public class LifeSlider : Slider
{
protected override void Start()
{
    base.Start();
    onValueChanged.AddListener(OnLifeChanged);
}

private void OnLifeChanged(float value)
{
    if (fillRect == null) return;
    fillRect.GetComponent<CanvasRenderer>().SetAlpha(value <= 0 ? 0 : 1);
}

    private void NewVisibility(){
        if(value == 0){
            fillRect.GetComponent<CanvasRenderer>().SetAlpha(0);
        }else{
            fillRect.GetComponent<CanvasRenderer>().SetAlpha(1);
            }
    }

    public void setVida(float vida){
        this.value = vida;
    }

    public void setVidaMaxima(float vida){
        this.maxValue = vida;
        this.value = vida;
    }
}

