using UnityEngine;

namespace MainAssets
{
    [CreateAssetMenu(fileName = "Quantity", menuName = "Quantity")]
    public class Quantity : ScriptableObject
    {
        public int number = 10;
        // Default number of squares generated. Could be changed by creating new gameobject from "Quantity" menu,
        // then replacing the ScriptableObject in GameObject called Inicialization AND Sphere.
        // Other option is to change the number in already created ScriptableObject called "Quantity".
    }
}