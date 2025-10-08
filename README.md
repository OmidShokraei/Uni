# 🎓 Uni — University Management Web Application

A full-featured university management platform developed with **ASP.NET (C#)** and **Microsoft SQL Server**.  
This project provides a modular backend for managing mentors, students, and courses, integrated with a lightweight frontend using **HTML**, **JavaScript**, **AJAX**, and **Razor Pages**.  
The focus of this project is on **robust backend architecture**, **secure APIs**, and **clean data handling**.

---

## 📑 Table of Contents

1. [Overview](#overview)
2. [Backend Architecture](#backend-architecture)
3. [Technologies Used](#technologies-used)
4. [Key Features](#key-features)
5. [Database Design](#database-design)
6. [API Endpoints](#api-endpoints)
7. [Security & Authentication](#security--authentication)
8. [Error Handling & Logging](#error-handling--logging)
9. [Project Setup](#project-setup)
10. [Sample Images](#sample-images)
11. [Future Improvements](#future-improvements)
12. [Author](#author)

---

## 🧭 Overview

**Uni** is a university-oriented platform that connects **students** and **mentors** through a structured and easy-to-use web interface.  
It provides tools for mentor management, student assignments, academic tracking, and reporting.  
The backend is built with scalability and modularity in mind, focusing on performance, maintainability, and security.

---

## 🏗️ Backend Architecture

The backend is based on a **multi-layer architecture**, separating the application into independent logical layers:

```

/Uni
├── Controllers/        # API endpoints and routing logic
├── Models/             # Entity, View, and DTO models
├── Services/           # Core business logic and validation
├── Data/               # Entity Framework / ADO.NET data access layer
├── mentor pics/        # UI sample images (for presentation)
├── Views/              # Razor Pages (frontend)
├── Scripts/            # JS, AJAX client-side logic
├── App_Start/          # Configurations (routes, filters, etc.)
├── Web.config          # Environment setup and connection strings
└── Global.asax         # Application entry point

````

Each layer follows **SOLID principles**, with clear separation between concerns.  
Controllers delegate work to **services**, which handle data through the **repository pattern**.

---

## ⚙️ Technologies Used

**Backend:**
- C# / ASP.NET MVC & Web API
- Entity Framework Core / ADO.NET
- Microsoft SQL Server (T-SQL)
- LINQ for data querying
- JSON Web Tokens (JWT)
- Dependency Injection (built-in DI)
- Serilog / built-in logging

**Frontend:**
- HTML5, CSS3, Bootstrap
- JavaScript, jQuery, AJAX
- Razor Views

**Other Tools:**
- Visual Studio 2019
- IIS / Kestrel for hosting
- Git & GitHub for version control

---

## 🚀 Key Features

- ✅ RESTful API endpoints for all core entities (Mentors, Students, Courses)
- ✅ Role-based authentication and authorization (Admin / Mentor / Student)
- ✅ Dynamic data rendering via AJAX
- ✅ Data validation and model binding
- ✅ Centralized error handling and structured logging
- ✅ Modular design for scalability and maintainability
- ✅ Responsive and user-friendly interface (Bootstrap)
- ✅ Configurable database connection via `Web.config`

---

## 🧩 Database Design

A relational schema designed for consistency and scalability:

**Main Tables:**
- **Mentors** → MentorId, Name, Email, Department, ProfileImage, etc.  
- **Students** → StudentId, Name, Email, Major, MentorId (FK)  
- **Courses** → CourseId, Title, Description, Credits  
- **Assignments** → Id, StudentId, MentorId, CourseId, Status, CreatedAt  
- **Users** → UserId, Username, PasswordHash, Role, CreatedAt  

All entities use **foreign key constraints**, **indexes** for performance, and **cascading deletes** where appropriate.

---

## 🧠 API Endpoints

| Area | Method | Endpoint | Description |
|------|--------|-----------|-------------|
| Mentor | GET | `/api/mentors` | Get all mentors |
| Mentor | POST | `/api/mentors` | Add a new mentor |
| Mentor | PUT | `/api/mentors/{id}` | Update mentor details |
| Mentor | DELETE | `/api/mentors/{id}` | Remove a mentor |
| Student | GET | `/api/students` | Retrieve all students |
| Course | POST | `/api/courses` | Create a new course |
| Auth | POST | `/api/auth/login` | Login and generate JWT |
| Auth | POST | `/api/auth/register` | Register a new user |

All endpoints return **JSON** responses and follow RESTful conventions.

---

## 🔐 Security & Authentication

Security is implemented at multiple levels:
- **JWT-based authentication**
- **Role-based authorization**
- **Password hashing and salting**
- **Input validation** against SQL injection and XSS
- **HTTPS enforcement**
- **CORS configuration** for API clients

---

## 🧾 Error Handling & Logging

All exceptions are managed by a global exception filter, returning structured error responses:
```json
{
  "error": "ValidationFailed",
  "message": "Invalid email address format.",
  "status": 400
}
````

* Errors are logged with **Serilog** or the built-in .NET logger.
* Logs include timestamps, user context, and stack traces.
* Supports multiple log levels: Debug, Info, Warning, Error.

---

## 🛠️ Project Setup

To run this project locally:

```bash
git clone https://github.com/OmidShokraei/Uni.git
cd Uni
```

1. Open the project in **Visual Studio**.
2. Configure your **SQL Server connection string** in `Web.config`.
3. Run database migrations (if applicable).
4. Press **F5** or run with IIS Express / Kestrel.
5. Test API endpoints via **Swagger** or **Postman**.

---

## 🖼️ Sample Images

Below are some screenshots from the `mentor pics` folder showcasing different parts of the platform:

| Description          | Screenshot                                      |
| -------------------- | ----------------------------------------------- |
| Mentor Dashboard     | ![Mentor Dashboard](mentor pics/image1.png)   |
| Student Management   | ![Student Management](mentor pics/image2.png) |
| Course Management    | ![Course Management](mentor pics/image3.png)  |
| Mentor Profile       | ![Mentor Profile](mentor pics/image4.png)     |
| Login Page           | ![Login Page](mentor pics/image5.png)         |
| Reports & Statistics | ![Reports](mentor pics/image6.png)            |

*(Update the file names according to your actual images.)*

---

## 🔮 Future Improvements

Planned or potential upgrades:

* Integration with **SignalR** for real-time updates
* Export reports (PDF / Excel)
* Advanced filtering and analytics
* Caching layer (Redis / MemoryCache)
* Improved test coverage (xUnit / NUnit)
* Docker-based deployment

---

## 👤 Author

**Developed by:** Omid Shokraei
**GitHub:** [OmidShokraei](https://github.com/OmidShokraei)

---

⭐ *This project demonstrates backend engineering skills, database design, and API development in ASP.NET.
It highlights a focus on clean architecture, modularity, and practical full-stack integration.*
