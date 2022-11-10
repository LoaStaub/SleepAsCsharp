# SleepAsCsharp
RestAPI catching API Calls from SleepAsAndroid, saving them into Database (LiteDB) and sending to Discord Webhook \
https://docs.sleep.urbandroid.org/services/custom_webhooks.html \
https://docs.sleep.urbandroid.org/services/automation.html#events \

# Needed Variables
- DOMAIN\
You should bind a Domain to your project but you can use a IP too, especially
if you host this in your private network.
- YOURNAME\
Here you need to pick a username. It is possible with this that multiple persons can use this, like your family.
You need to add this to the URL for your api (see how to use section)
- YOURKEY\
This is my first and easiest attempt to password proof the API so nobody could invade.
Just choose a key in appsettings.json under the section "KeyForWebhook".
You need to add this to the URL for your api (see how to use section)
- DISCORDWEBHOOKURL\
Create a webhook on a Channel in Discord. Add this URL into your appsettings.json under the section KeyForWebhook.

# How to SETUP
Download the Release (Win64) or build this project on your own \
Further tutorials will be provided soon \
Unzip or build into your hosting folder \
Host this ASP.NET Core Webapp \
You need ASP.NET Core Runtime and .NET Desktop Runtime \
https://dotnet.microsoft.com/en-us/download/dotnet/6.0 \

# How to USE
After hosting you need to set the webhook URL in SleepAsAndroid as: 
http[s]://DOMAIN/sleep/action?name=YOURNAME&key=YOURKEY \
And now it should work! \

Reminder: \
Do not forget to give rights to your Project, it needs to create a DB File.
