using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;

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

            //Character Nixon = CharacterManager.instance.CreateCharacter("Nixon");


            StartCoroutine(Test());

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator Test()
        {
            Character Boss = CharacterManager.instance.CreateCharacter("Boss");

            yield return new WaitForSeconds(1f);

            yield return Boss.Hide();

            yield return new WaitForSeconds(0.5f);

            yield return Boss.Show();

            yield return Boss.Say("Hi");


            //List<string> lines = new List<string>()
            //{
            //    "narrator \"Hi\"",
            //    "This is a line",
            //    "And another",
            //    "And a last one"
            //};
            //yield return DialogueSys.instance.Say(lines);

            //Debug.Log("Finished");




            //Character Nixon = CharacterManager.instance.CreateCharacter("Nixon");
            //Character Boss = CharacterManager.instance.CreateCharacter("Boss");
            //Character Hacker = CharacterManager.instance.CreateCharacter("Hacker");

            //List<string> lines = new List<string>()
            //{
            //    "Hi there!",
            //    "My name is Nixon",
            //    "Oh, {wa 1} that's very nice"
            //};

            //yield return Nixon.Say(lines);

            //lines = new List<string>()
            //{
            //    "I am the Boss",
            //    "More lines{c}Here."
            //};

            //yield return Boss.Say(lines);

            //yield return Hacker.Say("This is a line that I want to say.{a} It is a simple line.");

            //Debug.Log("Finished");


        }
    }
}