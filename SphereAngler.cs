using UnityEngine;

namespace MainAssets
{
    public class SphereAngler : MonoBehaviour
    {
        [SerializeField]private Quantity _quantity;
        private float _oneAngle;
        private float _radius;
        private Vector3 _newPos;

        private void Start()
        {
            _radius = (float)Random.Range(7,20) / 10;         // Assigning the radius from middle of the screen to generated cubes.
            _oneAngle = 360f / _quantity.number;                // Assigning the angle between two cubes.
            for (int i = 0; i < _quantity.number; i++)
            {
                _newPos = CalculatePosition(_radius, _oneAngle * i);                         // Calculating the position of the cube.
                GameObject.Find("go" + i).GetComponent<Transform>().position = _newPos;      // Changing the position of the cube.
            }
        }

        public Vector3 CalculatePosition(float radius, float angle)
        {
            Vector3 newPos;
            newPos.x = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            newPos.y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            newPos.z = 0;
            return newPos;
        }
    }
}