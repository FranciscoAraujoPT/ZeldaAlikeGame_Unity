using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;
    [HideInInspector]
    public float runTimeValue;

    public void OnAfterDeserialize()
    {
        runTimeValue = initialValue;
    }
    public void OnBeforeSerialize()
    {

    }
}
