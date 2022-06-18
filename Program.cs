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

            //string path = @"/home/nyvall/Desktop/Home/Programs/Desptop App Short/LogFolder/Log1.txt";
            //await File.WriteAllLinesAsync(path, outputString);
            
            System.Console.WriteLine("\n");
            foreach (var item in outputString){
                System.Console.WriteLine(item);
            }
        }

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
                "Distent path: ",
                "Content: ",
                "Timer: ",
                "Starting time: ",
                "time interval: ",
                "Time unit: ",
                "Eding Time: "
            };

            string tempAnwser = "";


            // debug
            //CheckIfQuestionAnswerIsCorrect("h", questions[8], questions);



            bool[] shouldQuestionBeAsked = new bool[3];

            string[]? outputString = new string[questions.Length];

            Console.Write(questions[0]);
            outputString[0] = Console.ReadLine();

            do{
                Console.Write(questions[1]);
                tempAnwser = Console.ReadLine();
                if (CheckIfQuestionAnswerIsCorrect(tempAnwser,questions[1], questions)){
                        outputString[1] = tempAnwser;
                        break;
                    }
            } while(true);
            

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
                    do{
                        Console.Write(questions[i]);
                        tempAnwser = Console.ReadLine();
                        if (CheckIfQuestionAnswerIsCorrect(tempAnwser,questions[i], questions)){
                            outputString[i] = tempAnwser;
                            break;
                        }                                      
                    } while (true);
                   }
               } else{
                   outputString[i] = "...";
               }
            }

            // Asks for timer setting
            do{
                Console.Write(questions[5]);
                tempAnwser = Console.ReadLine();
                if (CheckIfQuestionAnswerIsCorrect(tempAnwser,questions[5], questions)){
                    outputString[5] = tempAnwser;
                    break;
                }
            } while (true);
            

            if (string.Compare(outputString[5], "yes") == 0 || string.Compare(outputString[5], "y") == 0){
                for (int i = 6; i < questions.Length; i++){
                    do{
                        Console.Write(questions[i]);
                        tempAnwser = Console.ReadLine();
                        if (CheckIfQuestionAnswerIsCorrect(tempAnwser,questions[i], questions)){
                                outputString[i] = tempAnwser;
                                break;
                            }
                    } while (true);
                }
            } else{
                for (int i = 6; i < questions.Length; i++){
                    outputString[i] = "...";
                }
            }

            return outputString;
        }

        static bool CheckIfQuestionAnswerIsCorrect(object anwser, string question, string[] questions){
            // questions    0       1       2       3       4       5     6    7    8     9
            //              string, string, string, string, string, bool, int, int, char, int

            // True if action command is acceptable
            if (question == questions[1]){
                switch (anwser){
                    case "mkdir":
                        return true;
                        
                    case "fs":
                        return true;
                        
                    case "wr":
                        return true;
                        
                    case "comp":
                        return true;
                       
                    case "mv":
                        return true;
                        
                    case "re":
                        return true;
                        
                    case "op":
                        return true;
                        
                    case "run":
                        return true;  
                }
            }

            // True if dir does not exist
            if (question == questions[2] || question == questions[3]){
                if (Directory.Exists(anwser.ToString())){
                    return true;
                }
            }

            // True if the user types yes, y, no , n... Does not matter if it is capital
            if (question == questions[5]){
                if (string.Compare(anwser.ToString(), "yes") == 0 || string.Compare(anwser.ToString(), "y") == 0){
                    return true;
                }
            }

            // true if anwser is a number and not a charecter
            if (question == questions[6] || question == questions[7] || question == questions[9]){
                char num;
                for (int i = 0; i < anwser.ToString().Length; i++){
                    num = anwser.ToString()[i];
                    if (Char.IsNumber(num)){
                        return true;
                    }
                }
            }
           
            // True if the input is h, m or s
            if (question == questions[8]){
                if (anwser.ToString().Length < 2){
                    if (anwser.ToString() == "h" || anwser.ToString() == "m" || anwser.ToString() == "s"){
                        return true;
                    }
                }
            }

            return false;
        }

        #region Action
        static void createFolder(string path, string folderName){
            if (!Directory.Exists(path)){
                Directory.CreateDirectory(path);
                Console.WriteLine("Folder was created...");
            }
        }

        static void createFile(string path, string fileName){
            if (!File.Exists(path)){

            }
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

        #endregion Action
    }
}