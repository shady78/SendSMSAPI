# Vonage SMS Integration with ASP.NET Core

This project demonstrates how to send SMS messages using the [Vonage API (formerly Nexmo)](https://www.vonage.com/) in an ASP.NET Core Web API application.

## 🚀 Features

- Send SMS messages via Vonage API.
- Clean architecture using services and dependency injection.
- API endpoint for sending SMS using `POST /api/sms/send`.
- Configuration-driven setup via `appsettings.json`.
- Swagger integration for testing in development mode.

## 🛠️ Technologies Used

- .NET 6+
- ASP.NET Core Web API
- Vonage C# SDK (`Vonage` NuGet package)
- Swagger (Swashbuckle)

## 📦 Installation & Setup

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-username/vonage-sms-api.git
   cd vonage-sms-api
   ```
2. **Install the Vonage NuGet Package**

     ```bash
      dotnet add package Vonage
     ```
2. **Open the appsettings.json file and update the following section:**

   ```bash
      "VonageSms": {
      "ApiKey": "Your_Master_Key_d510a7f4",
      "ApiSecret": "Your_API_Secret_3rXxvjhCAdotcf3D",
      "FromNumber": "VonageAPIs"
      }
     ```
   
