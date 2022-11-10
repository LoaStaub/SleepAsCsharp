# TODO
- Better tutorial
- Better Release
- Multilingual and easy to change Event calls (Now only german and hardcoded)
- Release tutorial for own modification (saving in other databases, sending to other webhooks than Discord, etc.)
- MORE

# SleepAsCsharp
RestAPI catching API Calls from SleepAsAndroid, saving them into Database (LiteDB) and sending to Discord Webhook \
https://docs.sleep.urbandroid.org/services/custom_webhooks.html \
https://docs.sleep.urbandroid.org/services/automation.html#events 

# A few words from me
Hi, I am a huge fan of "Sleep as Android" since 10 years+. So as I was skipping through the settings, I found some automation possibilities. One of these options where "Webhooks". So I directly linked to Discord, but it never worked. At one day in my vacation I started this project and didn't stop until it was not finished. I wanted to have a software, I can use to use it in combination with discord, but to make it modular, so it can be used with everything else, like databases, other chatting platforms and maybe with API's of the variety of IOT (e.g. Smart Home). I think it could be nice, if somebody wants to automate his home to turn on the alarm, lock the door and stop the oven when "Felt asleep" event is triggered and the alarm gets automatically paused when you go to pee. So I wrote this and made it easy to edit for the own usecase by using object oriented programming language. You can see the Discord Linking and LiteDB interface as an example of the whole possibilities you have. I hope somebody fork this project and uses it for his own ideas. It is possibly my first public project, which has a nice usecase. I will promote this, when my todo list shrinks.

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
https://dotnet.microsoft.com/en-us/download/dotnet/6.0 

# How to USE
After hosting you need to set the webhook URL in SleepAsAndroid as: 
http[s]://DOMAIN/sleep/action?name=YOURNAME&key=YOURKEY \
And now it should work! 

Reminder: \
Do not forget to give rights to your Project, it needs to create a DB File.
