using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ColourTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //generate colours
    //Vector3 ExampleKeyColor = new Vector3(abs(sin(iTime + 12) + sin(iTime*0.7 + 71.124)*0.5),
                                 //abs(sin(iTime) + sinNewStruct0.8 + 41.)*0.5),
                                 //abs(sin(iTime+61.) + sin(iTime*0.8 + 831.32)*0.5));

    //call to change colour scheme
    //object SampleFromColorScheme(float r1, float r2, Color _Color1, Color _Color2, _Color3)
    //{
    //    return (1. — sqrt(r1))*_Color1 + (sqrt(r1) * (1. — r2))*_Color2 + (r2 * sqrt(r1)) * _Color3;
    //}

    private int sqrt(float r1)
    {
        throw new NotImplementedException();
    }
}

internal class abs
{
}

internal struct NewStruct
{
    //public iTime* Item1;
    public object Item2;

    //public NewStruct(iTime* item1, object item2)
    //{
    //    Item1 = item1;
    //    Item2 = item2;
    //}

    public override bool Equals(object obj) => obj is NewStruct other &&
               //EqualityComparer<iTime*>.Default.Equals(Item1, other.Item1) &&
               EqualityComparer<object>.Default.Equals(Item2, other.Item2);

    //public override int GetHashCode()
    //{
    //    return HashCode.Combine(Item1, Item2);
    //}

    //public void Deconstruct(out iTime* item1, out object item2)
    //{
    //    item1 = Item1;
    //    item2 = Item2;
    //}

    //public static implicit operator (iTime*, object)(NewStruct value)
    //{
    //    return (value.Item1, value.Item2);
    //}

    //public static implicit operator NewStruct((iTime*, object) value)
    //{
    //    return new NewStruct(value.Item1, value.Item2);
    //}

    #region og code
    //og system code
//    ExampleKeyColor = new Vector3(
//abs(sin(iTime+12.) + sin(iTime*0.7 + 71.124)*0.5)
//,abs(sin(iTime) + sin(iTime*0.8 + 41.)*0.5)
//,abs(sin(iTime+61.) + sin(iTime*0.8 + 831.32)*0.5))

    //og colour changer
    //Color SampleFromColorScheme(float r1, float r2, Color _Color1, Color _Color2, _Color3)
    //{
    //    return (1. — sqrt(r1))*_Color1 + (sqrt(r1) * (1. — r2))*_Color2
    //    + (r2 * sqrt(r1)) * _Color3;
    //}
    #endregion
}