using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MainAssets
{
    public class CubeManager : MonoBehaviour
    {
        public Vector2 direction;
        public float velocity;
        private float _radius;
        public List<GameObject> gameObjects;
        public bool pressed;

        private void Start()
        {
            _radius = GetComponent<Transform>().localScale.x;                   // Retriving the length of a cube.
            _radius = Mathf.Sqrt(Mathf.Pow(_radius, 2) * 2) / Mathf.Sqrt(2);    // Assigning the length from middle point to the vertex.
        }

        private void Update()
        {
            if (pressed)
            {
                foreach (var cube in gameObjects)
                {
                    var l = gameObjects.Count();
                    DetectCollision(cube);                  // Detecting the cube collisions. (see below)
                    if (l != gameObjects.Count()) break;    // If the list was modified,
                                                            // then the foreach stops and new loop starts with next frame.
                }
            }
        }

        // Detector for the cube collisions.
        private void DetectCollision(GameObject obj)
        {
            foreach (var oppositeCube in gameObjects.Where(x => x != obj))
            {
                var p1 = obj.GetComponent<Transform>().position;
                var p2 = oppositeCube.GetComponent<Transform>().position;
                if (Mathf.Abs(p1.x - p2.x) < _radius && Mathf.Abs(p1.y - p2.y) < _radius) // Checking if the distance between two cubes
                                                                                          // is lower than - the created before - radius.
                {
                    gameObjects.Remove(oppositeCube);   // Removing the cube from the list that collided with this cube.
                    gameObjects.Remove(obj);            // Removing the cube that has detected a collision.
                    Destroy(obj);                       // Destroying the cube that has detected a collision.
                    Destroy(oppositeCube);              // Destroying the cube from the list that collided with this cube.
                    return;
                }
            }
        }
    }
}