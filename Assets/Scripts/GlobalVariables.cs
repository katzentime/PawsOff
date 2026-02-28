using UnityEngine;
using UnityEngine.Serialization;

public class GlobalVariables : MonoBehaviour
{
    [FormerlySerializedAs("_dishes")] [SerializeField]
    public static GameObject[] Dishes;
    //Click Damage int variable
    //Score int variable
}