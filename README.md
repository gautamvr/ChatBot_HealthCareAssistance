# Chat-Bot providing Healthcare assistance

This application assists the end user in finding a suitable patient monitor/integrated solutions based on all products available along with the list of features of the product or a purchase suggestion based on specific features that the user prefers.
It has the test projects included which checks if the functions behave as desired. 
It has the solution file which opens the chatbot console application's codes and necassary files.

This repo also has NUnit console runner tool, which can be used to run the test cases.


## Release notes

It has a batch file *AutoBuildTest_ChatBot.bat* which can be run to test the project after making any changes in the codes.

This batch file builds, runs and reports a pass-fail-status. It gives an exit-code of 0 for success and non-zero for failure. This exit-code gives a summary of all tests performed.

NOTE : This application uses SQL server database to access the data for Patient monitors. This SQL server is remotely connected which uses the server's host computer's IP Address in the app.config file. This can be connected only when the user and the host computer are in the same network.

  
## UML Design Diagram:
![alt-text](https://github.com/gautamvr/ChatBot_HealthCareAssistance/blob/master/ChatBotDesignNew.png)
