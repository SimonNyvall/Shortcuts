using System;
using System.IO;
  
namespace ShortcutApp {
      
    class Program {
          
        static void Main(string[] args) {
              
            WriteToLogFile();
            //CreateLogFile();

            Console.ReadKey();
        }

        static async void WriteToLogFile(){

            string[] outputString = LogQuestions();

            string path = @"/home/nyvall/Desktop/Home/Programs/Desptop App Short/LogFolder/Log1.txt";
            await File.WriteAllLinesAsync(path, outputString);

        }

        #region Actions
        static string[] LogQuestions(){

             // Example of log file
            /*
                Short Name : My Shortcut
                Action : MoveFile
                Origigal Path : Home/programs/...
                Distent path : Home/programs/...
                Timer : Yes
                Staring time : 15 00
                Time interval : 3
                Time Unit : h
                Ending time : 22 00
            */

            string[] questions = {
                "Shortcut name: ",
                "Action: ",
                "Origigal path: ",
                "Distent path",
                "Content: ",
                "Timer: ",
                "Starting time: ",
                "time interval: ",
                "Time unit: ",
                "Eding Time: "
            };

            bool[] shouldQuestionBeAsked = new bool[3];

            string[]? outputString = new string[questions.Length];

            Console.Write(questions[0]);
            outputString[0] = Console.ReadLine();

            Console.Write(questions[1]);
            outputString[1] = Console.ReadLine();

            // Check which command the user want to run and toggle the correct questions
            switch (outputString[1]){
                case "mkdir":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = false;
                    break;
                case "fs":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = false;
                    break;
                case "wr":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = true;
                    break;
                case "comp":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = false;
                    break;
                case "mv":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = true;
                    shouldQuestionBeAsked[2] = false;
                    break;
                case "re":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = false;
                    break;
                case "op":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = false;
                    break;
                case "run":
                    shouldQuestionBeAsked[0] = true;
                    shouldQuestionBeAsked[1] = false;
                    shouldQuestionBeAsked[2] = false;
                    break;
            }

            // write in the paths the user puts in
            for (int i = 2; i < 5; i++){
               if (i <= shouldQuestionBeAsked.Length){
                   if (shouldQuestionBeAsked[i - 2] == true){
                   Console.Write(questions[i]);
                   outputString[i] = Console.ReadLine();
                   }
               } else{
                   outputString[i] = "...";
               }
            }

            // Asks for timer setting
            Console.Write(questions[5]);
            outputString[5] = Console.ReadLine();

            if (string.Compare(outputString[5], "yes") == 0 || string.Compare(outputString[5], "y") == 0){
                for (int i = 6; i < questions.Length; i++){
                    Console.Write(questions[i]);
                    outputString[i] = Console.ReadLine();
                }
            } else{
                for (int i = 6; i < questions.Length; i++){
                    outputString[i] = "...";
                }
            }

            return outputString;
        }

        static void createFolder(string path, string folderName){
            if (!Directory.Exists(path){
                Directory.CreateDirectory(path);
                Console.WriteLine("Folder was created...");
            })
        }

        static void createFile(string path, string fileName){

        }

        static void writeToFile(string path, string content){

        }

        static void compressfile(string path){

        }

        static void moveFile(string currentPath, string disieredPath){

        }

        static void renameFile(string path, string name){

        }

        static void runScript(string path){

        }

        #endregion Actions
    }
}