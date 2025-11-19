# TODO List Tracker

A cloud-based TODO list tracker built with **C# and ASP.NET Core**.  
Manage tasks efficiently: create, edit, delete, and track progress.

---

## Features
- Add, edit, and delete tasks
- Track status: **Pending**, **In Progress**, **Completed**
- **AWS** integration
- Responsive interface

---

## Tech Stack
- **C#** & **ASP.NET Core**
- **Entity Framework Core**
- **MySQL / SQL Server**
- **Bootstrap** for frontend
- **AWS SDK**

---

## Quick Start
1. Clone the repo:  
   ```bash
   git clone https://github.com/FatimaElmi/TODO-list-tracker.git
   ```

2. Open in Visual Studio

3. Restore NuGet packages

4. Update appsettings.json with your database connection

5. Build and run (F5 or dotnet run)

6. Optional: Configure AWS credentials if using cloud features

## Team Workflow
- **main**: Stable branch  
- **dev**: Development branch
  
## Using the dev Branch

1. Clone the repository (if not done already):
```
bash
 git clone https://github.com/FatimaElmi/TODO-list-tracker.git
cd TODO-list-tracker
```
2. Switch to the dev branch:
   ``` bash
   git checkout dev
```
3. Work on features or fixes
* Open the project in Visual Studio
* Make your changes (add tasks, edit code, etc.)

4. Stage and commit changes:
```bash
git add .
git commit -m "Brief description of your changes"
```
5. Push changes to the remote dev branch:
```bash
git push
```
6. Pull latest updates before starting new work:
```bash
git pull origin dev
```
7. Merge dev into main via Pull Request
* Go to GitHub → Pull Requests → New Pull Request
* Base branch: main, Compare branch: dev
* Review, create PR, and merge when approved

 Each team member should:
1. Commit and push changes
2. Open Pull Requests to merge into main

# Contributing

1. **Fork the repository**
2. **Create a feature branch**  
3. **Commit and push changes**  
4. **Open a Pull Request to dev**
