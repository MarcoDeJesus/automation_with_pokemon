# automation_101

This project has all libraries needed to run already installed.

To Build This Project from scratch, you will need to download some packages in Visual Studio 2019:
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




