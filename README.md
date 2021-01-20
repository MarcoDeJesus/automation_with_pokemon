# automation_with_pokemon

### Purpose ###

The goal behind this project is to be able to ATDD(BDD) and UnitTesting in something I'm very familiar with, which are the Pokemon Games. the idea is to use existing API's, WebPages and Classes of my Own for didactic purposes.

Used API: https://pokeapi.co/
Used Web Page: https://pokemondb.net/



### Prerequisites and Setup ###

Visual Studio 2019 must be installed on the system for this project to run. The project in this repository has all libraries needed to run already installed.

But, in order to build this Project from scratch, you will need to download these packages in Visual Studio 2019 using the NuGet manager:
- Selenium.WebDriver.ChromeDriver
- Selenium.WebDriver.GeckoDriver.Win64
- Selenium.Support
- Selenium.WebDriver
- NUnit
- NUnit3Adapter
- Restsharp
- Specflow
- Specflow.NUnit
- Specflow.Tool.MsBuild.Generation
- Newtonsoft.Json


Configure Chromedriver to be available anywhere in your PC:
- Open C:\
- Create a folder in C:\, named "webdrivers"
- Download the latest version of Chromedriver from here: https://chromedriver.chromium.org/downloads
- Unzip the file and move "chromedriver.exe" to the C:\webdrivers\ directory
- In Windows search bar, enter "Env"
- Select "Edit the System Environment variables"
- Click the "Environment variables" button in the window presented to you
- Search for "PATH" under "System Variables"
- Edit "PATH" 
- Enter a new value at the bottom like this: C:\webdrivers
- Save and Save



### Test Execution ###

To run test the user needs to use Visual Studio Test Explorer under the Test main menu. All existing test will be displayed there.


