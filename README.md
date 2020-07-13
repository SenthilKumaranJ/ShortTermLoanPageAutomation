# ShortTermLoanPageAutomation
ShortTermLoanPageAutomation
Auden Assignment: c# Specflow

Goals/ Focus on

1.	Creating project from Scratch
a.	No code reuse from previous
b.	Project must be simpler and smaller
2.	Meet as many specified test conditions as possible
a.	3 test assertions specified
b.	Have to use slider only. No shortcuts
c.	Do not click on button
3.	Finish by target of 3 Hours (total work time). 

Tools:
Framework: c# with Specflow (targeted to .NET core 2.1)
I had issues updating and pointing the solution to .NET core 3.1. But, I did not want to waste my time on this problem given the time constraint.
IDE: Visual Studio 2019 Community Edition
Dependencies:
Started with installing the following dependencies.
•	SpecFlow.Nunit
•	SpecFlow.Tools.MsBuild.Generation
•	Selenium.WebDriver
Then added a few more based on need
•	DotNetSeleniumExtras.WaitHelpers (for wait until clickable, visible, etc)
•	Selenium.Support
Final list of Dependencies:
 
Approach:
1.	Keep the work simple and work with fewer components possible.
2.	Focus on three components 
a.	Feature file with readable scenarios. Create a ‘feature’folder for this
b.	Page Objects (and actions). Create ‘page’ folder for this
c.	Step definitions that bind the feature to page objects and actions. Create a ‘step’ folder for this. All this is to give structure and discipline to the code.
3.	Write a competent feature file that addresses/ meets all the mandatory assertions
4.	Right click the entire feature file and click on create step definitions. Click on copy to clipboard
5.	Create a new step definitions cs file in the step folder
6.	Paste the step definitions copied to clipboard to this file
7.	Create a page.cs file in ‘page’ folder to capture page objects and define page objects
8.	Capture the page objects. It is  Ideal to go with CSS selectors. This is based on experience. Even if the page layout changes slightly the css selector still work as they tend to carry on using the same set of identifiers. 
9.	Write constructors and functions for the actions and manipulations that need to be carried out on the page like finding the next Sunday from today, Extracting day out of the given day, etc
10.	In the step definitions cs file, replace the default unimplemented code with calls to the methods in steps page. This binds the steps in the feature file to the actions done in the page.cs file
11.	As a good practice, it is good to have opening the url, closing down the driver, etc in a different component. These are defined in the hook.cs file.

Issues Faced/help sought:
1.	Slider object handling. This was new to me
Resolution: Solution from selenium.dev  site on how to use DragandDropbyOffset feature
2.	Get day value of friday:
a.	Stackoverflow suggested solution of parsing the date from application to date time object and extract ‘ddd’ from the date in the process
