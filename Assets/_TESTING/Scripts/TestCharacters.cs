using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;

namespace TESTING
{
    public class TestCharacters : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Character character = CharacterManager.instance.CreateCharacter("Michael");
            //Character Michael = CharacterManager.instance.CreateCharacter("Michael");
            //Character Michael2 = CharacterManager.instance.CreateCharacter("Michael");

            Character femaleStudent2 = CharacterManager.instance.CreateCharacter("Female Student 2");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}