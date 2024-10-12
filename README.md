# WhatsApp.Api.Otp Demo API Project

This demo API project demonstrates how to use the `WhatsApp.Api.Otp` NuGet package to send OTP messages via WhatsApp Business APIs. It provides a sample implementation to streamline your integration process.

## Sample .NET Api project using this nuget package

WhatsApp Api Otp nuget package Git Repository - https://github.com/evotechcraft/WhatsApp.Api.Otp

## Project Structure

- **Controllers**: Contains the `WhatsappMessageController` to handle API requests.
- **Services**: Implements the `IWAOtpService` for sending OTP messages.
- **Configuration**: Manages access to the WhatsApp Business API.

## Prerequisites

- A valid WhatsApp Business API details

## Getting Started

### Installation

Clone the repository and navigate to the project directory. Install the required NuGet package:

```bash
dotnet add package WhatsApp.Api.Otp
```

## Configuration
Update your appsettings.json with the necessary WhatsApp configurations:
```json
"WhatsAppConfigurations": {
  "ApiUrl": "https://graph.facebook.com",
  "PhoneNumberId": "your_phone_number_id",
  "AccessToken": "your_access_token",
  "Version": "v20.0"
}
```

## Dependency Injection Setup
In Program.cs, add the required service dependencies:
``` csharp
builder.Services.AddWAApiDependency(builder.Configuration, "WhatsAppConfigurations");
```

## API Controller Example
The WhatsappMessageController handles OTP message sending:

``` csharp
using Microsoft.AspNetCore.Mvc;
using WhatsApp.Api.Otp.Common.Request;
using WhatsApp.Api.Otp.Contracts;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsappMessageController : ControllerBase
    {
        private readonly IWAOtpService _wAOtp;

        public WhatsappMessageController(IWAOtpService wAOtp)
        {
            _wAOtp = wAOtp;
        }

        [HttpPost("SendOtpMessage")]
        public async Task<IActionResult> SendOtpMessage(OtpMessageModel message)
        {
            var response = await _wAOtp.SendOtpMessageAsync(message);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
```

## Running the Project
Build and Run the project:
```
dotnet build
dotnet run
```

## Use an API client like Postman to test the endpoint:

``` curl
curl --location 'https://zerotech.me/api/v1/WhatsappOtpMessage/SendOtpMessage' \
--header 'accept: */*' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer {{API Token}}' \
--data '{
  "templateName": "{{TemplateName}}",
  "recipientNumber": "{{RecipientNumber}}",
  "otp": "{{Otp}}",
  "language": {{TemplateLanguage}}
}'
```

## Support
For any questions or issues, please contact support at sales@evotechcraft.com.

## License
This demo project is licensed under the MIT License. See the LICENSE file for more details.


This README file explains setting up and using the demo API project with the `WhatsApp.Api.Otp` package. Feel free to adjust contact and configuration details to fit your specific setup.
