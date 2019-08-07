# Fortnite Stats - Stream Overlay Integration

README is __WIP__.
This program allows you to add your Fortnite stats to your stream overlay. The program currently outputs files for `Total Duo Kills and Wins, Total Lifetime Kills and Wins, Total Solo Kills and Wins, Total Squad Kills and Wins, and Current Stream Session Wins`. Working on Win Streak output as well. You could ultimately add these stats to a Twitch chat bot as well, but the current plan is to set up micro features for streaming and letting the end users pick the features they want to use.

## Application Setup

__Get your API key here:__ [FortniteTracker](https://fortnitetracker.com/site-api)
You may need to generate a new API Key if you have an old one or you are get `Invalid Authentication Credentials` from the server. [Tracker Network](https://tracker.gg/developers) has added a developer dashboard to handle Keys for all game titles.

The Fortnite Tracker endpoint is currently:
`https://api.fortnitetracker.com/v1/profile/{platform}/{epic-nickname}`
There are additional endpoint available now. I'll be exploring them to see if they could be useful here.

The three platforms are pc, xbl, and psn. You'll have to pick the correct platform for the epic nickname. I would suggest going to [Fortnite Tracker](https://fortnitetracker.com) and verifying that the nickname is correct. Sometimes the gamertag will be different than the epic nickname.

In `Program.cs` update username and platform:
```cs
string epicUserName = "ninja"; 
string platform = "pc";
```
In `Data.cs` update the request with your API Key:
```cs
request.AddHeader("TRN-Api-Key", "YOUR_KEY_HERE");
```

***

## Steam Setup
Just going to show how to bring in text files to the most common streaming software. For now that will be OBS and Xsplit.

### [OBS](https://obsproject.com/)
These steps were last tested with OBS version 22.0.2

- Open OBS and go to the scene that will use the data.
- Click the plus sign to add a new source. Then select the "Text (GDI+)" option.

![Add text file source](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/OBS%20add%20source.png "Add text file source")
- A sub menu will open. You can name your new source here if you wish. Click "OK" when you are finished.

![Name your scene](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/OBS%20name%20source.png "Name your scene")
- The next menu will let you configure the text's display on the stream. Here we will add the file we wish to display. Select the check box "Read from file" and then select "Browse". Navigate to the location of the saved files. You'll need to run the app once or you will not have your files yet.

![Add your text file](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/OBS%20read%20from%20file.png "Add you text file")
- You can customize the font, color, background and a few other options, but at this point you are done with adding the files. Click "OK" and then position and resize as you need within your scene.

### [Xsplit](https://www.xsplit.com/)
These steps were last tested with Xsplit version 3.6 and a premium license.

- Open Xsplit and go to the scene that will use the data.
- Select "Add source" and then click "Text...".

![Add text file source](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/Xsplit%20add%20source.png "Add text file source")
- A sub menu will open, click the check box "Use custom script" and then select "Edit Script".

![Edit script](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/Xsplit%20add%20script.png "Edit Script")
- From the "Template" drop down select "Load Text from Local File".

![Load text from local file](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/Xsplit%20edit%20script.png "Load text from local file")
- In the settings tab go to the "File Path" option and navigate to the location of the saved files. You'll need to run the app once or you will not have your files yet.

![Add file path](https://github.com/I-M-G/BlackOps4Stats/blob/master/images/Xsplit%20add%20text%20file.png "Add file path")
- In this menu you can also add an update interval. This will check the file for changes every X amount of seconds. Probably best to keep this low, so your stream is getting the new data when it's pushed to the file. Not sure about any performance issues a smaller number could have.
- Finally, click "Update Text" and you are essentially done. You can customize the font, color, background and a few other options at this point. Click "OK" and then position and resize as you need within your scene.
