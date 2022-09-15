using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MainAssets
{
    public class CubeDisplay : MonoBehaviour
    {
        [SerializeField] private Quantity _quantity;
        [SerializeField] private Mesh _cube;
        [SerializeField] private Material _cubeMaterial;
        private bool _pressed;
        public List<GameObject> gameObjects = new();

        // Adding components to every created cubes.
        private List<GameObject> PopulateCubes(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                GameObject go = new GameObject();
                go.name = "go" + i;
                go.tag = "Cube"; // Assigning the tag, which will be searched for everytime the counter should be updated.
                go.AddComponent<MeshFilter>();
                go.AddComponent<CubeManager>();
                go.AddComponent<MeshRenderer>();
                go.GetComponent<MeshRenderer>().material = _cubeMaterial;                                     // Assigning the created before material to a cube.
                go.GetComponent<MeshFilter>().mesh = _cube;                                                   // Assigning the cube mesh.
                go.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 0.2f);                      // Assigning the length of a cube.
                go.GetComponent<CubeManager>().velocity = (float)UnityEngine.Random.Range(1, 2) / 10 * 3;     // Generating the velocity of a cube.

                // Generating the direction of a cube.
                go.GetComponent<CubeManager>().direction = new Vector3((float)UnityEngine.Random.Range(-45, 45) / 10, (float)UnityEngine.Random.Range(-45, 45) / 10);
            }
            return GameObject.FindGameObjectsWithTag("Cube").ToList();
        }

        private void OnEnable()
        {
            gameObjects = PopulateCubes(_quantity.number); // Creating the list of GameObjects, having only cubes.
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) { _pressed = true; }       // Listener for space key which starts the main program.
            if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }   // Listener for escape key which quits the program.
        }

        private void FixedUpdate()
        {
            if (_pressed) //
            {
                foreach (var item in gameObjects)
                {
                    item.GetComponent<CubeManager>().gameObjects = gameObjects;     // Passing the list of GameObjects to every cube.
                    item.GetComponent<CubeManager>().pressed = true;                // Passing the information of pressed space key.

                    // Moving the cubes.
                    item?.transform.Translate(new Vector3(item.GetComponent<CubeManager>().direction.x * item.GetComponent<CubeManager>().velocity * Time.deltaTime, item.GetComponent<CubeManager>().direction.y * item.GetComponent<CubeManager>().velocity * Time.deltaTime));

                    // Checking if cubes are outside of the camera view.
                    var go = item.GetComponent<Transform>().position;
                    if (go.y > 2.8
                        || go.x > 4.5
                        || go.x < -4.5
                        || go.y < -2.8
                        || !item.GetComponent<Renderer>().isVisible) // I did it very basic,
                                                                     // because isVisible() function didn't work properly when I've tested it.
                    {
                        gameObjects.Remove(item); // Removing the cube from the list.
                        Destroy(item); // Destroying the cube.
                        break;
                    }
                }
            }
        }
    }
}