<div align="center">

# Pierre's Sweet and Savory Treats

</div>

<div align="center">
<img src="https://github.com/agatakolohe.png" width="200px" height="auto" >
</div>
<h3 align="center">Authentication with Identity, 01-15-2021</h3>
<h4 align="center"> By Agata Kolodziej</h4>

## Description

Eleventh independent project for Epicodus to demonstrate my understanding of authentication and authorization with Identity. This is an MVC web application written in C# using MySQL for the database functionality. I used Identity to create functionality for a user to register, log in, and log out. This application allows logged in users to have the ability to create, update and delete flavors and treats. All users are able to have the read functionality. This is a many-to-many database relationship between Treats and Flavors. A treat can have many flavors (sweet, salty, spicy) and a flavor can have many treats (cheesecake, bagels, croissants).

## User Stories

<details>
  <summary>Expand</summary>

- The application should have user authentication. A user should be able to log in and log out.
- Only logged in users should have create, update and delete functionality.
- All users should be able to have read functionality.
- There should be a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.
- A user should be able to navigate to a splash page that lists all treats and flavors.
- Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

</details>

## Setup/Installation Requirements

##### Software Requirements

1. Internet browser
2. A code editor such as VSCode to view and edit the code
3. .NET or follow along with the Installing .NET instructions to install .NET

##### Open Locally

- Click on the link to my repository: [My Repository](https://github.com/agatakolohe/PierresTreats.Solution.git)
- Click on the green "Code" button and copy the repository URL
- Open your terminal and use the command `git clone https://github.com/agatakolohe/PierresTreats.Solution.git` into the directory you would like to clone the repository
- Open in text editor to view code and make changes

##### Installing .NET

In order to run the application, please install .NET for your computer to recognize the `dotnet` command.

1. Download [.NET Core SDK (Software Development Kit)](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer). Clicking this link will prompt a file download for your particular OS from Microsoft.
2. Open the file. Follow the installation steps.
3. Confirm the installation is successful by opening your terminal and running the command `dotnet --version`. The response should be something similar to this:`2.2.105`. This means it was successfully installed.

##### Installing MySQL

MySQL is a type of database software used to create, edit, query, and manage SQL data.

- For Mac Users please [Click Here](https://dev.mysql.com/downloads/file/?id=484914) to download MySQL Installer
- For Windows Users please [Click Here](https://dev.mysql.com/downloads/file/?id=484919)

- Verify MySQL installation by opening the terminal and entering the command `mysql -uroot -p[THEPASSWORDYOUSELECTED]`
- If you gain access you will see see the MYSQL command line!

##### Installing MySQL Workbench

- Please [Click Here](https://dev.mysql.com/downloads/workbench/) to install the correct version for your machine
- Open MySQL Workbench and select `Local instance 3306 server`. You will need to enter the password you selected

##### Compiling

- Navigate to the Inventory folder in the command line
- Use the command `dotnet build` to compile

##### Installing Packages

- Navigate to the Inventory folder in the command line
- Use the command `dotnet restore`

<details>

  <summary>Expand for Database Installation Essentials!</summary>

### Database Connection

Create a connection string to connect the database to the web application

1. Create a file in the root directory called `appsettings.json`
2. Add the code below:

```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=agata_kolodziej_pierres_treats;uid=root;pwd=YourPassword;"
    }
}
```

- Put in your MySQL password in `pwd=YourPassword`. Change the server, port, and uid if necessary.

### Import Database Using Entity Framework Core

1. Navigate to Inventory directory in terminal
2. Use the command `dotnet ef database update` to generate the database through Entity Framework Core

### Update Database Using Entity Framework Core

1. Write any new code you wish to add to the database. Use the command `dotnet build` to check for any compiling errors. If no errors, proceed to step 2.
2. To update the database with any changes made to the code, use the command `dotnet ef migrations add [MigrationsName]`
3. Use the command `dotnet ef database update` to update the database

### Update Database Using MySQL Workbench

1. Open MySQL Workbench
2. Click on Server > Data Import in the top navigation bar
3. Select `Import from Self-Contained File`
4. Select the `Default Target Schema` or create new schema
5. Select all Schema Objects you would like to import
6. Select `Dump Structure and Data`
7. Click `Start Import`

</details>

##### View In Browser

- To view in browser, navigate to Inventory folder in the command line
- Use the command `dotnet run` to execute the compiled code and start a localhost
- In browser navigate to http://localhost:5000
- From the splash page you can view all the current treats and flavors
- Click on Register in top nav bar to create an account
- If you have an account, click Log In in the top nav bar to be able to create, edit, and delete treats and flavors
- To log out, click the Log Out button in the top nav bar
- Enjoy the application!

## Known Bugs

If you decide to change the styling of the application and you do not see your updated styles in the browser, please open a new Incognito Window in your browser and you should be able to see your updated styles. The browser caches styles and therefore may not show changes.

## Support and Contact Details

If any errors or bugs occur with installation, delete both bin and obj folders and follow the Compiling and Installing Packages instructions again. Get help or report a bug you have found in the .NET platform at [.NET Support](https://dotnet.microsoft.com/platform/support). Or please email me, <agatakolohe@gmail.com>.

## Technologies Used

- .NET Core 2.2.0
- ASP.NET Core MVC
- ASP.NET Core Razor Pages
- Bootstrap
- C# 7.3
- CSS
- Entity Framework Core
- GitHub
- HTML
- MySQL
- MySQL Workbench
- [Unsplash](https://unsplash.com/)
- VS Code

### License

This software is licensed under the [MIT License](https://choosealicense.com/licenses/mit/).

Copyright (c) 2021 Agata Kolodziej <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8Q_3EVY7j95tTyemJwWxMR7jwvUK7gPe0_w&usqp=CAU" width="2%" height="auto">
