using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{

    public Slider sldr;
    public Text sldrtxt;
    public Text txt;
    public Text killtext;


   public void hp(float a, float b)
    {
        sldr.GetComponent<Slider>().maxValue = a;
        sldr.GetComponent<Slider>().value = b;
        sldrtxt.GetComponent<Text>().text = b.ToString() + " / " + a.ToString();
    }
    
   public void kill(int a)
    {
        txt.GetComponent<Text>().text = "Kill: " + a.ToString();
    }

    public void killText()
    {

        killtext.gameObject.SetActive(!killtext.IsActive());
    }





}
