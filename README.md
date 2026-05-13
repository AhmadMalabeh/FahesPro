[README.md](https://github.com/user-attachments/files/27707080/README.md)
# 🚗 FahesPro: Car Inspection & Management System

**Tech Stack:** C# | .NET Framework 4.8 | SQL Server

### 📖 Overview
FahesPro is a comprehensive Windows Desktop application designed for car inspection centers to manage testing processes, generate reports, and store vehicle data. This project was developed as part of my academic coursework to apply real-world software engineering principles.

### 🛠 Key Features
* **Car Registration & Tracking:** Log vehicle details (VIN, make, model, owner).
* **Inspection Workflows:** Step-by-step guidance for vehicle technical inspection.
* **Report Generation:** Professional PDF/printable test reports.
* **Data Management:** Secure storage and retrieval of inspection history.

### 💻 Technical Stack
* **Language:** C#
* **Framework:** .NET Framework 4.8 (WinForms for UI)
* **Database:** Microsoft SQL Server
* **Database Access:** ADO.NET

### 🏗 Architecture
The project implements a **3-Tier Architecture** for maintainability and scalability:
1. **Presentation Layer (UI):** Built with Windows Forms.
2. **Business Logic Layer (BLL):** Handles validation and business rules.
3. **Data Access Layer (DAL):** Manages all database interactions.

---

### 🚀 How to Run the Project (Getting Started)

To run this project locally on your machine, please follow these steps:

**1. Prerequisites:**
* Visual Studio (with .NET desktop development workload).
* Microsoft SQL Server & SQL Server Management Studio (SSMS).

**2. Database Setup:**
* Go to the `Database` folder in this repository.
* You will find a database backup file named `FahesPro_DB.bak`.
* Open SSMS, right-click on "Databases" -> "Restore Database" -> choose "Device" and select the `.bak` file to restore it.

**3. Update Connection String (Crucial Step):**
* Open the solution (`.sln`) in Visual Studio.
* Navigate to the Data Access Layer (DAL).
* Update the `ConnectionString` to match your local SQL Server instance name.

**4. Dependencies & Reporting:**
* This project uses the **Syncfusion** library for generating printable car inspection reports.
* Visual Studio will automatically restore the required Syncfusion NuGet packages upon the first build.
* *Note: The Syncfusion license key has been removed from `Program.cs` for security and best-practice reasons. A standard Syncfusion watermark/popup may appear when generating reports unless you provide your own key.*

**5. Build and Run:**
* Clean and Build the solution to restore any missing NuGet packages.
* Press `F5` or click "Start" to run the application.

### 📸 **Screenshots**

<img width="1178" height="668" alt="Main Screen" src="https://github.com/user-attachments/assets/890447ca-ebbc-4dca-a174-25e67189744e" />
<img width="1247" height="674" alt="Test Screen" src="https://github.com/user-attachments/assets/a73a9311-1653-4684-9d3d-ff035f9807a9" />
<img width="1280" height="710" alt="Rating Screen" src="https://github.com/user-attachments/assets/3c46b594-9c4f-44b3-aa38-58713f276957" />
<img width="1260" height="681" alt="Search Screen" src="https://github.com/user-attachments/assets/c3ca4753-5940-4928-8b29-11b1f8dc2eea" />
<img width="1172" height="675" alt="Reports Screen" src="https://github.com/user-attachments/assets/0a6d06db-7acf-4ca5-92ad-f09e071a07bc" />
<img width="1174" height="672" alt="Chart Screen" src="https://github.com/user-attachments/assets/758b700a-0718-4201-856d-01fbd54fd555" />





