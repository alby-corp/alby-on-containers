﻿dotnet user-secrets set "RabbitMQ:Username" "guest"
dotnet user-secrets set "RabbitMQ:Password" "guest"
dotnet user-secrets set "Email:SmtpUsername" ""
dotnet user-secrets set "Email:SmtpPassword" ""
dotnet user-secrets set "Email:SmtpServer" ""
dotnet user-secrets set "Email:SmtpPort" 
dotnet user-secrets set "Email:DefaultSenderName" ""
dotnet user-secrets set "Email:DefaultSenderEmail" ""
dotnet user-secrets set "Email:UseSsl": ""

dotnet user-secrets remove "RabbitMQ:Username"
dotnet user-secrets remove "RabbitMQ:Password"
dotnet user-secrets remove "RabbitMQ:Username"
dotnet user-secrets remove "RabbitMQ:Password"
dotnet user-secrets remove "Email:SmtpUsername"
dotnet user-secrets remove "Email:SmtpPassword"
dotnet user-secrets remove "Email:SmtpServer"
dotnet user-secrets remove "Email:SmtpPort"
dotnet user-secrets remove "Email:DefaultSenderName"
dotnet user-secrets remove "Email:DefaultSenderEmail"
dotnet user-secrets remove "Email:UseSsl"
