# SleepAsCsharp
RestAPI catching API Calls from SleepAsAndroid, saving them into Database (LiteDB) and sending to Discord Webhook \
https://docs.sleep.urbandroid.org/services/custom_webhooks.html \
https://docs.sleep.urbandroid.org/services/automation.html#events \

# How to Use
Download the Release \
Unzip into your hosting folder \
Host this ASP.NET Core Webapp \
You need ASP.NET Core Runtime and .NET Desktop Runtime \
https://dotnet.microsoft.com/en-us/download/dotnet/6.0 \
After hosting you need to set the webhook URL in SleepAsAndroid as: 
http[s]:://yourURLorIP/sleep/action?name=YOURNAME&key=lstb12 \
And now it should work! \

Reminder: \
Do not forget to give rights to your Project, it needs to create a DB File.