
### Class Library vs Web API Parent

| Feature	                    | Class Library 📦      | Web API 🌐
| ------------------------------|-----------------------|---------------|
| Middleware Configurations     | ✅ Yes                |❌ No          |
| Dependency Injection (DI)     | ✅ Yes                |❌ No          |
| Shared Business Logic	        | ✅ Yes                |❌ No          |
| Exposes HTTP Endpoints	    | ❌ No                 |✅ Yes         |
| Centralized Authentication    | ❌ No                 |✅ Yes         |
| Centralized Logging	        | ❌ No                 |✅ Yes         |


# 🏗️ Microservices Architecture with Shared Functionality

This project demonstrates a **.NET microservices architecture** with a **shared library** for common functionality and a **Web API** for reusable services.

## 📂 Project Structure  

| Folder/Project        | Type                | Description |
|-----------------------|---------------------|-------------|
| `CommonLibrary`       | Class Library       | Contains shared logic, DTOs, extensions, and utilities. |
| `CommonServicesAPI`   | Web API             | Centralized API for authentication, logging, etc. |
| `OrderService`        | Web API (Microservice) | Handles order management. |
| `ProductService`      | Web API (Microservice) | Manages product-related operations. |
| `API Gateway`         | API Gateway (Ocelot) | Routes requests to appropriate services. |
| `docker-compose.yml`  | Docker Configuration | Orchestrates microservices deployment. |
