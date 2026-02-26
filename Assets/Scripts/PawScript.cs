using UnityEngine;

//Add a serialized field for "Target Food" GameObject
//Serialized Field for "Speed" float
//Serialized Field for "Health" int
//Serialized Field for "Reached" bool

public class PawScript : MonoBehaviour
{
    void Start()
    {
        //Pick a random Dish and set it to Target Food
        //Should spawn at a random point around the edge of the table, but should be close to the target food
    }

    void Update()
    {
        //Check if "Reached" is true, if true then add the food in scene as a child of the paw + return to original position

        //Move towards the food based on the speed
        //When reaching dish, set "Reached" to true

        //On click, should reduce health by 1 (for now, will need to add a global variable for the click damage)
        //after the click, check for health, and if <1 then destroy self
    }
}
