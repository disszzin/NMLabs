# NMLabs

An application for solving laboratory work in the discipline "numerical methods for solving hydrometeorological problems"

## What do you need to run?

Before you start, make sure that the **.NET 8.0 SDK** is installed on your computer.

**How to check if it is installed .NET?**

1. Open a command prompt (Windows: `Cmd or PowerShell`, Mac/Linux: `Terminal`).
2. Enter the command and press `Enter`:

   ```
   dotnet --version
   ```
3. If you see the version number (for example, `8.0.201`), then everything is ready. If an error occurs, it means .NET is not installed.

### Installation .NET SDK

If.NET is not installed, download and install it from the official website absolutely for free.

* **Download link:** [https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
* Select the version for your operating system (Windows, macOS or Linux) and install the **SDK** following the instructions of the installer.

---

## Start-up instructions (step by step)

### 1. Download the source code

Click on the green **"Code"** button at the top of this page and select **"Download ZIP"**.

Unzip the downloaded ZIP file to a folder that is convenient for you (for example, in `Downloads `or `Desktop`).

### 2. Open the command prompt in the project folder

This is the most important step. You need to open a terminal window (command line) in the folder where the file `NMLabs.csproj` (and/or `.sln`) is located.

**The easiest way (for Windows):**

1. Open the folder with your project in the **Explorer**.
2. Hold down the `Shift` key on your keyboard and **right-click** on an empty place in the folder.
3. In the menu that appears, select **"Open a PowerShell window here"** or **"Open the command window here"**.

**For macOS and Linux:**
Open the Terminal and use the `cd` command to navigate to the project folder.

```
cd ~/Downloads/NMLabs # Example for the Downloads folder
```

### 3. Launch the app

Enter the following command in the command prompt window that opens and press `Enter`:

```
dotnet run
```

**It's done!** If everything is done correctly, your console application will start, and you will see the result of its work directly on the command line.
