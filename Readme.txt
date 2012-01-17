=NuGardt ESL Wire Plugin Match Reminder v1.0.0.0=
 Author: Kevin 'OomJan' Gardthausen
 Last Update: 17.01.2012

 The match reminder is a plugin for ESL Wire (http://www.esl.eu/wire).

 This plugin lets your manage reminders for your upcoming matches. Never forget a match while you are actually sitting at your PC and forgetting the time while watching streams for instance.

 Notifications can be shown in game (through ESL Wire when supported), via a balloon popup on the taskbar and voice announcement (Text-To-Speech).

 Set multiple notifications before the scheduled start of match, set different options for each notification.

 Want more stuff in this plugin? Message me with your suggestions or do it yourself! This plugin is open source. Written in Visual Basic.NET. Source codes available on http://code.google.com/p/eslwirematchremindernet/ (GNU GPL v3 License).


==Requirements==
 * ESL Wire (http://www.esl.eu/eu/wire)
 * Microsoft .NET Framework 3.5 (http://www.microsoft.com/download/en/details.aspx?id=21)


==Installation==
 Using the installer, point it to the directory of your ESL Wire installation.

 Using the archive, put its contents into the \plugins folder of your ESL Wire Installation.

 ESL Wire is installed by default to: "C:\Program Files\EslWire" (This may be different to you)


==Notification message format place holders==
In the notification text you can insert place holders that will be filled by the plugin with data automatically.

 * $gameid$
 * The ESL game identifier
 * Example: "687" (for StarCraft II)

 * $gametitle$
 * The title of the game
 * Example: "StarCraft II"

 * $id$
 * The ESL match identifier

 * $leaguecountry$
 * The country region of the match
 * Example: "eu" (for Europe), "de" (For Germany)

 * $leagueid$
 * The ESL league identifier

 * $leaguename$
 * The name of the league
 * Example: "StarCraft II 1on1 Amateur Series"

 * $mode$
 * The play mode
 * Example: "player"

 * $name$
 * The name of the match
 * Example: "vs. OomJan"

 * $time$
 * The time when the match starts

 * $uri$
 * The link to the match
 * Example: "http://www.esl.eu/eu/sc2/1on1/eas/match/1337/"

 * $timetomatch$
 * The time remaining till the match starts
 * Example: "1 day 14 hours 37 minutes 2 seconds"


==Open source==
 Download the source at http://code.google.com/p/eslwirematchremindernet/ or vis Subversion (SVN): svn checkout http://eslwirematchremindernet.googlecode.com/svn/ eslwirematchremindernet-read-only

 Written with Microsoft Visual Studio 2010 in .NET Framework 3.5. Installer done with Nullsoft NSIS 2.46 (http://nsis.sourceforge.net/Main_Page). Archived using Rarlab Winrar (http://www.rarlab.com/).


==Support==
 E-mail: kevin@nugardt.com
 Twitter: http://www.twitter.com/oomjan34


==License==
 NuGardt ESL Wire Plugin Match Reminder
 Copyright (C) 2012 NuGardt Software
 http://www.nugardt.com

 This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

 This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.

 You should have received a copy of the GNU General Public License along with this program.  If not, see <http://www.gnu.org/licenses/>.

