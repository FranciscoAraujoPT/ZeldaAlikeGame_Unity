using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeartPlus;
    public Sprite halfFullHeart;
    public Sprite halfFullHeartMinus;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int counter = 0; counter < heartContainers.initialValue; counter++)
        {
            hearts[counter].gameObject.SetActive(true);
            hearts[counter].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runTimeValue / 4;
        for (int counter = 0; counter < heartContainers.runTimeValue; counter++)
        {
            float currHeart = Mathf.Ceil(tempHealth - 1);
            if (counter <= tempHealth - 1)
            {
                //FullHeart
                hearts[counter].sprite = fullHeart;
            }
            else if (counter >= tempHealth)
            {
                //emptyHeart
                hearts[counter].sprite = emptyHeart;
            }
            else if (counter == currHeart && (tempHealth % 1) == .50)
            {
                //Half full heart
                hearts[counter].sprite = halfFullHeart;
            }
            else if (counter == currHeart && (tempHealth % 1) == .25)
            {
                //1/4 heart
                hearts[counter].sprite = halfFullHeartMinus;
            }
            else if (counter == currHeart && (tempHealth % 1) == .75)
            {
                //3/4 heart
                hearts[counter].sprite = halfFullHeartPlus;
            }
        }
    }
}
