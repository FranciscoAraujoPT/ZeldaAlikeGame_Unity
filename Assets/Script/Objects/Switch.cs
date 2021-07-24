using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool active;
    public boolValue storedValue;
    public Door thisDoor;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        active = storedValue.runTimeValue;
        if (active)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        active = true;
        storedValue.runTimeValue = active;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}
