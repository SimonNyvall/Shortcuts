using System;
using ShortActions;
using ShortCreate;

namespace ShortMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Actons objAction = new Actons();
            Create objCreate = new Create();

            bool validAnwser = false;
            string[] commands = { "crate", "run" };

            Console.WriteLine("Welcome to shortcut");
            while (validAnwser == false)
            {
                Console.WriteLine(">:");

                string anwser = Console.ReadLine() ?? string.Empty;

                foreach (var valid in commands)
                {
                    if (string.Equals(valid, anwser))
                    {
                        validAnwser = true;

                        //derect to right class
                        if (valid == commands[0]){
                            // do
                            objCreate.CreateAction();
                        } else if (valid == commands[1]){
                            // do
                            objAction.doAction("test");
                        }
                    } else{
                        Console.WriteLine("Wrong input");
                    } 
                }

                if (anwser == "exit")
                {
                    break;
                }
            }
        }
    }
}