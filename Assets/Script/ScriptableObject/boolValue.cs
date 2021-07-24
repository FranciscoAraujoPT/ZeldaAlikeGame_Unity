using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class boolValue : ScriptableObject, ISerializationCallbackReceiver
{
    public bool initialValue;
    [HideInInspector]
    public bool runTimeValue;

    public void OnAfterDeserialize()
    {
        runTimeValue = initialValue;
    }
    public void OnBeforeSerialize()
    {

    }
}
