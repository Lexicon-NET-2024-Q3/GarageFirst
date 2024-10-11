// See https://aka.ms/new-console-template for more information

var cui = new ConsoleUI();
uint capacity = cui.AskForUint(
           query: "Enter capacity for the new garage:",
           successFeedback: $"A new garage was succesfully created!"
       );
var handler = new GarageHandler(capacity);
var manager = new Manager(cui, handler);
manager.Run();
