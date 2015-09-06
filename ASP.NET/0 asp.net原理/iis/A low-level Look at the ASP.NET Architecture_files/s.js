// -----------------------------------------------------------------------------------------------
// (C) Copyright 2011 by Lake Quincy Media. All rights reserved.
//
// Common code for m.js
// -----------------------------------------------------------------------------------------------

if ( LqmAds === undefined )
{
    var LqmAds =
    {
        //-----------------------------------------------------------------------------------------
        // Search term stuff

        GetQueryTerms: function () {
            // common search engine domains with their search term querystring parameter
            var searchEngines = [
                { d: "www.google.", q: "q=" },
                { d: "www.bing.com", q: "q=" },
                { d: "search.live.com", q: "q=" },
                { d: "search.yahoo.com", q: "p=" },
                { d: "codeproject.com", q: "q=" },
                { d: "msdn.microsoft.com", q: "query=" },
                { d: "localhost", q: "q=" }
            ];

            function GetSearchTermKey(url) {
                var searchKey = "";
                for (var i = 0; i < searchEngines.length; i++) {
                    var se = searchEngines[i];
                    if (url.indexOf(se.d) >= 0) {
                        searchKey = se.q;
                        break;
                    }
                }
                return searchKey;
            };

            function GetQueryStringParameter(searchKeyTerm, referrer) {
                var startPos = referrer.toLowerCase().indexOf(searchKeyTerm);
                if ((startPos < 0) || (startPos + searchKeyTerm.length >= referrer.length)) {
                    return "";
                }
                var endPos = referrer.indexOf("&", startPos);
                if (endPos < 0) {
                    endPos = referrer.length;
                }

                var queryString = referrer.substring(startPos + searchKeyTerm.length, endPos);
                // fix the space characters
                queryString = decodeURIComponent(queryString);
                //queryString = queryString.replace( /%20/gi, " " );
                //queryString = queryString.replace( /\+/gi, " " );
                // remove the quotes (if you're really creative, you could search for the
                // terms within the quotes as phrases, and everything else as single terms)
                //queryString = queryString.replace( /%22/gi, "" );
                queryString = queryString.replace(/\"/gi, "");

                return queryString;
            };

            function FormatSearchTerms(searchQuery) {
                if (searchQuery == undefined)
                    return "";

                // matches anything the is NOT a search term
                var rgxQueryStripper = /\bAND\b|\bNOT\b|^NOT\b|\bOR\b|[^A-Z0-9\+\-\#\._\s]+|\b[A-Z0-9]+:/gi;

                // TODO: get rid of jQuery
                // strip out all the non-terms such as AND, NOT, OR, &, field:, (, ), +, -
                var formattedSearchTerms = searchQuery.replace(/^\s+|\s+$/gi, "");
                if (formattedSearchTerms) {
                    formattedSearchTerms = formattedSearchTerms.replace(rgxQueryStripper, " ");

                    // strip out multiple whitespace charaters and and commas.
                    formattedSearchTerms = formattedSearchTerms.replace(/\s+/g, " ");

                    return formattedSearchTerms;
                }
                else {
                    return "";
                }
            };

            var url = document.URL;
            var searchTerms = "";
            var searchTermKey = GetSearchTermKey(url);

            if (searchTermKey != "") {
                searchTerms = FormatSearchTerms(GetQueryStringParameter(searchTermKey, url));
            }

            if (searchTerms == "") {
                url = document.referrer.toLocaleLowerCase();
                if (!url)
                    return "";

                searchTermKey = GetSearchTermKey(url);

                if (searchTermKey != "") {
                    searchTerms = FormatSearchTerms(GetQueryStringParameter(searchTermKey, url));
                }
            }

            return searchTerms;
        },

        // End of Search Term stuff
        //-----------------------------------------------------------------------------------------

        // generate a random ID for the page
        GetRandom: function (len, base) {
            var result, i, j;
            result = '';
            for (j = 0; j < len; j++) {
                i = Math.floor(Math.random() * base).toString(base).toUpperCase();
                result = result + i;
            }
            return result;
        },

        //-----------------------------------------------------------------------------------------
        // Tag stuff
        PageRandomNumber: null,
        PageSearchTerms: null,
        Tile: 1,

        BuildIFrameTag: function (requestData) {
            var tagHtml =
            "<iframe id=\"lqmad{tile}\" ";
            if (requestData && requestData.width && requestData.width > 1)
                tagHtml = tagHtml + "width=\"{width}\" ";
            else
                tagHtml = tagHtml + "width=\"100%\" ";

            if (requestData && requestData.height && requestData.height > 0)
                tagHtml = tagHtml + "height=\"{height}\" ";
            else
                tagHtml = tagHtml + "height=\"0\" ";

            tagHtml = tagHtml + "marginwidth=\"0\" marginheight=\"0\" frameborder=\"0\" scrolling=\"no\">"
                              + "</iframe>";

            return this.ReplacePlaceholders(tagHtml, requestData);
        },

        BuildJavaScriptTag: function (requestData) {
            var tagJS = "<scri" + "pt language=\"JavaScript\" " +
            "src=\"" + window.location.protocol + 
            "//ad.doubleclick.net/adj/{sitename}/{zonename};{searchterm}sz={format};{type}tile={tile};ord={timestamp}?\" " +
            "type=\"text/javascript\"></scri" + "pt>";

            return this.ReplacePlaceholders(tagJS, requestData);
        },

        ReplacePlaceholders: function (tagHtml, requestData) {
            tagHtml = tagHtml.replace(/\{sitename\}/g, requestData.sitename);
            tagHtml = tagHtml.replace(/\{zonename\}/g, requestData.zonename);

            if (requestData.tags)
                tagHtml = tagHtml.replace(/\{searchterm\}/g, "kw=" +
                    encodeURIComponent(this.EscapeSpecialCharacters(requestData)) + ";");
            else
                tagHtml = tagHtml.replace(/\{searchterm\}/g, "");

            tagHtml = tagHtml.replace(/\{tile\}/g, requestData.tile.toString());
            tagHtml = tagHtml.replace(/\{format\}/g, requestData.format);
            tagHtml = tagHtml.replace(/\{width\}/g, requestData.width);
            tagHtml = tagHtml.replace(/\{height\}/g, requestData.height);
            tagHtml = tagHtml.replace(/\{target\}/g, requestData.target);
            tagHtml = tagHtml.replace(/\{timestamp\}/g, this.PageRandomNumber);

            if (requestData.type)
                tagHtml = tagHtml.replace(/\{type\}/g, "type=" + encodeURIComponent(requestData.type) + ";");
            else
                tagHtml = tagHtml.replace(/\{type\}/g, "");

            return tagHtml;
        },

        EscapeSpecialCharacters: function(requestData)
        {
            var tags = requestData.tags;
            tags = tags.replace(/\+/gi, "{plus}");
            tags = tags.replace(/\#/gi, "{sharp}");
            tags = tags.replace(/\./gi, "{dot}");

            // remove the other 'special characters'
            tags = tags.replace(/[\#\*\.\(\)\+\<\>\[\]]/gi, "");

            return tags;
        },

        // End of Tag Stuff
        //-----------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------
        // Mapping from Lake Quincy to DART information

        tagInfo: [
        //ID	Name	                                Height      Width
            {id: 1, n: 'Standard Banner', h: 60, w: 468 },
            { id: 2, n: 'Product Spotlight', h: 2, w: 1 },
            { id: 3, n: 'Hosting Spotlight', h: 2, w: 1 },
            { id: 4, n: 'Skyscraper', h: 600, w: 120 },
            { id: 5, n: 'Square', h: 125, w: 125 },
            { id: 6, n: 'Medium Rectangle', h: 250, w: 300 },
            { id: 7, n: 'Large Rectangle', h: 280, w: 336 },
            { id: 8, n: 'Leaderboard', h: 90, w: 728 },
            { id: 9, n: 'HTML Ad', h: 0, w: 0 },
            { id: 10, n: 'Fixed Square', h: 125, w: 125 },
            { id: 11, n: 'Fixed Banner', h: 60, w: 468 },
            { id: 12, n: 'Half Skyscraper', h: 300, w: 120 },
            { id: 13, n: 'IAB Button', h: 90, w: 120 },
            { id: 14, n: 'Rectangle', h: 120, w: 150 },
            { id: 15, n: 'Thin Horizontal', h: 27, w: 408 },
            { id: 16, n: 'Button', h: 30, w: 100 },
            { id: 17, n: 'DogEar', h: 0, w: 0 },
            { id: 18, n: 'Wide Skyscraper', h: 600, w: 160 },
            { id: 19, n: 'Tracking Only', h: 1, w: 1 },
            { id: 20, n: 'Mixed 120x90-Text', h: 5, w: 1 },
            { id: 21, n: 'Home page top left (150 X 80)', h: 80, w: 150 },
            { id: 22, n: 'SponsorEmail', h: 0, w: 0 },
            { id: 23, n: 'Email', h: 60, w: 60 },
            { id: 24, n: 'TextLinks', h: 0, w: 0 },
            { id: 25, n: 'Zone', h: 0, w: 0 },
            { id: 26, n: 'Goal group', h: 0, w: 0 },
            { id: 27, n: 'Article', h: 0, w: 0 },
            { id: 28, n: 'Search Sponsor Box', h: 30, w: 120 },
            { id: 29, n: 'Microbar', h: 31, w: 88 },
            { id: 30, n: 'Sponsor Link', h: 1, w: 0 }
        ],

        DetermineTagSize: function (requestData) {
            if (requestData.format) {
                if (isNaN(requestData.format)) {
                    var adSize = requestData.format.split("x");
                    if (adSize.length == 2) {
                        if (isFinite(adSize[0]))
                            requestData.width = adSize[0];
                        if (isFinite(adSize[1]))
                            requestData.height = adSize[1];
                    }
                }
                else {
                    var found = false;
                    var i = 0;
                    while (i < this.tagInfo.length && !found) {
                        var adFormat = this.tagInfo[i];
                        if (adFormat.id == requestData.format) {
                            if (adFormat.w != 0)
                                requestData.width = adFormat.w;
                            if (adFormat.h != 0)
                                requestData.height = adFormat.h;
                            requestData.type = adFormat.name;
                            found = true;
                            requestData.format = "" + adFormat.w + "x" + adFormat.h;
                        }
                        i++;
                    }
                }
            }
        },

        lqmIdToDartMap: [
        // Lake Quincy Publisher Site ID	DART Site Name	Site Name
		/* 1 Feb 2012 - time to cut the cord on these guys.
            {id: 558, n: "netmixer" },           //.NET Mixer
            {id: 777, n: "netrock" },            //.NET Rocker - Silverlight, SharePoint, and All things .NET
            {id: 483, n: "netstuff" },           //.NET Stuff from My Desktop
            {id: 735, n: "nettechq" },           //.Net Technoloy Quest
            {id: 462, n: "adilswebblog" },       //Adil's Weblog
            {id: 807, n: "alnyveldt" },          //Al Nyveldt's Blog
            {id: 383, n: "andreavb" },           //AndreaVB Programming
            {id: 599, n: "apulvyas" },           //Apul Vyas' Blog
            {id: 4287, n: "artem" },             //Artem's Blog
            {id: 207, n: "ashishware" },         //Ashishware
            {id: 49, n: "aspadvice" },           //ASP Advice
            {id: 1, n: "aspa" },                 //ASP Alliance
            {id: 33, n: "aspauthors" },          //ASP Authors
            {id: 224, n: "aspnetcodes" },        //ASP.NET Codes
            {id: 433, n: "aspnetfaq" },          //ASP.NET FAQ
            {id: 237, n: "aspnetmvc" },          //ASP.NET MVC
            {id: 8699, n: "aspnetpond" },        //ASP.NET Pond
            {id: 20, n: "aspsmith" },            //ASPSmith
            {id: 322, n: "ayenderahiens" },      //Ayende Rahien's Blog
            {id: 309, n: "azurefeeds" },         //Azure Feeds
            {id: 160, n: "beansoftware" },       //Bean Software
            {id: 302, n: "billbeckelman" },      //Bill Beckelman's Blog
            {id: 79, n: "bipinjoshi" },          //Bipin Joshi's Code
            {id: 155, n: "bipinjoshinet" },      //Bipin Joshi's Blog
            {id: 763, n: "blueonion" },          //Blue Onion Software
            {id: 1129, n: "bobcraven" },         //Bob Cravens' Blog
            {id: 589, n: "brentlamborn" },       //Brent Lamborn's Blog
            {id: 381, n: "brianpeek" },          //Brian Peek's Blog
            {id: 413, n: "bytemycode" },         //byte My Code
            {id: 610, n: "cfanatic" },           //C Fanatic
            {id: 732, n: "cprogramming" },       //C Programming
            {id: 240, n: "csharpfriends" },      //C Sharpfriends 
            {id: 172, n: "csharpfeeds" },        //C# Feeds
            {id: 756, n: "cametoofar" },         //CameTooFar
            {id: 9225, n: "chriskoenig" },       //Chris Koenig's Blog
            {id: 345, n: "codeaspnet" },         //Code ASP.NET
            {id: 445, n: "codepaste" },          //CodePaste.NET
            {id: 321, n: "codeinstinct" },       //Coding Instinct
            {id: 699, n: "compgroups" },         //Compgroups.net
            {id: 59, n: "connectionstrings" },   //Connection Strings
            {id: 6, n: "coveryourasp" },         //CoverYourASP
            {id: 4222, n: "dailynettips" },      //Daily .NET Tips
            {id: 92, n: "databasedev" },         //DatabaseDev.co.uk
            {id: 672, n: "debugging" },          //Debugging.com
            {id: 8314, n: "deliciousdotnet" },   //Delicious Dot Net
            {id: 4253, n: "delta" },             //Delta's Blog
            {id: 842, n: "devhawk" },            //DevHawk.net
            {id: 1160, n: "devlico" },           //Devlicio.us
            {id: 810, n: "dimecast" },           //Dimecast.net
            {id: 245, n: "directoryprogram" },   //Directory Programming .NET
            {id: 29, n: "dotnet247" },           //Dot Net 247
            {id: 185, n: "dotnetalbum" },        //Dot Net Album
            {id: 44, n: "dotnetjohn" },          //Dot Net John
            {id: 752, n: "dotnetprogram" },      //Dot Net Programming Made Easy
            {id: 70, n: "dotnetslackers" },      //Dot Net Slackers
            {id: 611, n: "dotnetspeaks" },       //Dot Net Speaks
            {id: 713, n: "dotnetsquare" },       //Dot Net Square
            {id: 285, n: "dotnettipstricks" },   //Dot Net Tips & Tricks
            {id: 623, n: "dotnetuncle" },        //Dot Net Uncle
            {id: 6259, n: "eaglet" },            //eaglet.cnblogs
            {id: 621, n: "edutechnow" },         //Education Technology Now
            {id: 835, n: "elegantcode" },        //Elegant Code
            {id: 895, n: "elijahmanor" },        //Elijah Manor
            {id: 199, n: "encosia" },            //Encosia
            {id: 4233, n: "everythingsilverlight" }, //Everything Silverlight
            {id: 617, n: "f1tutorials" },        //F1Tutorials
            {id: 799, n: "frazzleddad" },        //Frazzleddad
            {id: 825, n: "galasoftlaurent" },    //Galasoft Laurent Bugnion's Blog
            {id: 4223, n: "geeksoncoding" },     //Geeks On Coding
            {id: 560, n: "geekswithblogs" },     //Geekswithblogs.net
            {id: 1099, n: "gilfink" },           //Gil Fink's Blog
            {id: 654, n: "go4answers" },         //Go4Answers
            {id: 9076, n: "goodcoderscode" },    //good coders code, great coders reuse
            {id: 1025, n: "gurushop" },          //GuruStop - .NET & Web Dev Posts
            {id: 208, n: "ineta" },              //INETA North America
            {id: 8460, n: "integratedwebsys" },  //Integrated Web Systems
            {id: 193, n: "Iserializable" },      //ISerializable
            {id: 90, n: "jasongaylord" },        //Jason Gaylord's Blog
            {id: 9185, n: "javaeclipseandroid" }, //Java, Eclipse, Android and Web Programming Tutorials
            {id: 4213, n: "jeffblankenburg" },   //Jeff Blankenburg's Blog
            {id: 1066, n: "jeffhandley" },       //Jeff Handley
            {id: 230, n: "jeffreypalermo" },     //Jeffrey Palermo
            {id: 1041, n: "jessliberty" },       //Jesse Liberty's Blog
            {id: 785, n: "jongalloway" },        //Jon Galloway
            {id: 4212, n: "karlfleischmann" },   //KarlFleischmann.com
            {id: 62, n: "kbalertz" },            //kbAlertz.com
            {id: 811, n: "keithelder" },         //Keith Elder
            {id: 823, n: "kenegozi" },           //Kenegozi Blog
            {id: 774, n: "kevindockx" },         //Kevin Dockx's Blog
            {id: 822, n: "kevinpang" },          //Kevin Pang's Blog
            {id: 162, n: "kodyaz" },             //Kodyaz
            {id: 1121, n: "krisvandermast" },    //Kris van der Mast's Blog
            {id: 814, n: "lazycoder" },          //Lazy Coder
            {id: 175, n: "learnxpress" },        //Learn xpress
            {id: 656, n: "learnentityframework" }, //LearnEntityFramework
            {id: 701, n: "learningsharepoint" }, //Learning sharePoint
            {id: 841, n: "leedumond" },          //Lee Dumond's Blog
            {id: 7206, n: "lexli" },             //Lex Li's blog
            {id: 812, n: "lostechies" },         //Los Techies.
            {id: 693, n: "markysegger" },        //Markus Egger's Xamalot
            {id: 4214, n: "mehmetakif" },        //Mehmet Akif CAKAR's Web Blog
            {id: 798, n: "michaeleaton" },       //Michael Eaton's Blog
            {id: 781, n: "msftaccesshelpctr" },  //Microsoft Access Help Center
            {id: 288, n: "msftconsultants" },    //Microsoft Consultant's World
            {id: 736, n: "msfttechnologies" },   //Microsoft Technologies
            {id: 279, n: "moses" },              //Moses' Blog
            {id: 541, n: "msdotnetmentor" },     //MS Dot Net Mentor
            {id: 533, n: "msgroups" },           //MSGroups.net
            {id: 956, n: "mvwood" },             //MVWood.com
            {id: 751, n: "net-info" },           //net-informations.com
            {id: 578, n: "netprogramminghelp" }, //NetProgrammingHelp
            {id: 459, n: "niksgaur" },           //Niksgaur's Blog
            {id: 659, n: "nlogadvanced" },       //NLog - Advanced .NET
            {id: 843, n: "olegsych" },           //Oleg Sych's Blog
            {id: 768, n: "omnitechnews" },       //OmniTechNews
            {id: 264, n: "paraswadehramsdn" },   //Paras Wadehra MSDN Blog
            {id: 209, n: "peterritchie" },       //Peter Ritchie's MVP blog
            {id: 269, n: "powershell" },         //Powershell
            {id: 166, n: "realwrldsoftware" },   //Real World Software Architecture
            {id: 107, n: "regexadvice" },        //Regex Advice
            {id: 50, n: "regexlib" },            //RegExLib
            {id: 8202, n: "richardbanks" },      //Richard Banks - Agile and .NET
            {id: 258, n: "rickstrahl" },         //Rick Strahl's Web Log
            {id: 987, n: "robmensching" },       //Rob Mensching's Blog
            {id: 862, n: "robzelt" },            //Rob Zelt's Blog
            {id: 639, n: "rtsevenlite" },        //RT Seven Lite
            {id: 570, n: "rtwincustomize" },     //RT WinCustomize
            {id: 204, n: "ryandunn" },           //Ryan Dunn's Blog
            {id: 818, n: "ryanfarley" },         //Ryan Farley's Blog
            {id: 597, n: "sachabarber" },        //Sacha Barber's Blog
            {id: 1013, n: "samuelmoura" },       //Samuel Moura Development Blog
            {id: 454, n: "satalajmore" },        //satalaj More
            {id: 263, n: "scottallen" },         //Scott Allen's Blog
            {id: 52, n: "scottonwriting" },      //ScottOnWriting
            {id: 594, n: "senthikumaitpror" },   //Senthil Kumar - ITPRO 
            {id: 517, n: "senthikumar" },        //Senthil Kumar
            {id: 7895, n: "sharepointcoding" },  //Sharepoint Codings
            {id: 446, n: "sharepointkb" },       //Sharepoint KB
            {id: 635, n: "sharepointprogramming" }, //SharePoint Programming
            {id: 177, n: "shiningstarserv" },    //Shining Star Services, LLC
            {id: 380, n: "shrinkrays" },         //Shrinkrays
            {id: 398, n: "silverlightcream" },   //Silverlight Cream
            {id: 314, n: "silverlightfeeds" },   //Silverlight Feeds
            {id: 4229, n: "silverlightzone" },   //Silverlight-Zone
            {id: 834, n: "slickticket" },        //Slick Ticket
            {id: 357, n: "smallorkarounds" },    //Small Workarounds
            {id: 1028, n: "smartypantscoding" }, //Smarty Pants Coding
            {id: 8748, n: "snippertbank" },      //Snippet Bank
            {id: 965, n: "snowball" },           //Snowball - The Blog
            {id: 105, n: "sqladvice" },          //SQL Advice
            {id: 315, n: "sqlfeeds" },           //SQL Feeds
            {id: 7889, n: "sqlserver_busint" },  //SQL Server and Business Intelligence by Gaurav Mittal 
            {id: 488, n: "sqlservercitation" },  //SQL Server Citation
            {id: 333, n: "sqlserverdba" },       //SQL Server DBA
            {id: 352, n: "sqltips_tricks" },     //SQL Tips & Tricks
            {id: 18, n: "stardeveloper" },       //StarDeveloper
            {id: 72, n: "steveorr,site" },       //Steve Orr's Blog
            {id: 608, n: "snilyadav" },          //Sunil Yadav's Blog
            {id: 215, n: "tamirkhason" },        //Tamir Khason's Blog
            {id: 542, n: "techtalks" },          //Tech Talks
            {id: 800, n: "techtool" },           //Tech Tool Blog
            {id: 4250, n: "technoscatter" },     //Technoscatter - Drive to Technology
            {id: 440, n: "thecodecollege" },     //The Code College .NET
            {id: 284, n: "thecodecube" },        //The Code Cube - IT Community
            {id: 4266, n: "thecodeking" },       //The Code King
            {id: 283, n: "thecodeonline" },      //The Code Online
            {id: 4269, n: "thecustomizewindows" }, //The Customize Windows
            {id: 655, n: "thedatafarm" },        //the Data Farm
            {id: 8084, n: "thedotthenet" },      //The Dot The Net
            {id: 5838, n: "thoughonnet" },       //Thoughts on .NET
            {id: 115, n: "timheuer" },           //Tim Heuer's Blog
            {id: 312, n: "tipsntricks" },        //Tips n Tracks
            {id: 1120, n: "vascooliveria" },     //Vasco Oliveira's Blog
            {id: 292, n: "vbatips_tricks" },     //VBA Tips & Tricks
            {id: 463, n: "visualbasicknowbase" }, //Visual Basic Knowledge Base
            {id: 607, n: "visualbasictut" },     //Visual basic.Net tutorial
            {id: 408, n: "visualckicks" },       //Visual C# Kicks
            {id: 630, n: "way2tutorial" },       //Way2Tutorial  Free Web Development Tutorial
            {id: 591, n: "webnet" },             //Web.NET
            {id: 625, n: "wedostforum" },        //Wedost Forum
            {id: 110, n: "west-windtech" },      //West-Wind Technologies
            {id: 817, n: "wildermuth" },         //Wildermuth
            {id: 532, n: "williablog" },         //Williablog
            {id: 108, n: "windowsadvice" },      //Windows Advice
            {id: 391, n: "wynapse" },            //WynApse
            {id: 106, n: "xmladvice" },          //XML Advice
            {id: 23, n: "xmlforasp" },           //XMLforASP.NET
            {id: 694, n: "yaronnaveh" },         //Yaron Naveh's Web Services 2.0 Blog
            {id: 514, n: "yazilimmutfagi" },     //Yazilim Mutfagi
			*/
            {id: 782, n: "youvebeenhacked"}      //You've Been Haacked
        ],

        MapLqmIdsToDart: function (requestData) {
            if (requestData.publisher) {
                if (isNaN(requestData.publisher)) {
                    requestData.sitename = requestData.publisher;
                }
                else {
                    var found = false;
                    var i = 0;
                    while (i < this.lqmIdToDartMap.length && !found) {
                        if (this.lqmIdToDartMap[i].id == requestData.publisher) {
                            requestData.sitename = "lqm." + this.lqmIdToDartMap[i].n + ".site";
                            found = true;
                        }
                        i++;
                    }
                    if (!found) {
                        requestData.sitename = "lqm.pub" + requestData.publisher + ".site";
                    }
                }

                this.MapLqmZoneToDartZone(requestData);

            }
            else if (requestData.site) {
                requestData.sitename = "lqm.codeplex.site";
                if (requestData.charity)
                    requestData.zonename = "donated2charity";
                else
                    requestData.zonename = requestData.site.toLowerCase();
            }
        },

        zoneInfo: [
        // general
            { id: 1,  n: "ron" },
            { id: 51, n: "it" },
            { id: 52, n: "designer" },
            { id: 2,  n: "above_the_fold" },
            { id: 9,  n: "wpf" },
            { id: 14, n: "silverlight" },

        // Asp Alliance
            { id: 3, n: "reportingservices" },
            { id: 4, n: "sql" },
            { id: 5, n: "whitepaper" },
            { id: 6, n: "featuredwhitepaper" },
            { id: 7, n: "crystalreports" },
            { id: 10, n: "vs2005video" },
            { id: 11, n: "ros_dogear" },
            { id: 12, n: "homepage_dogear" },
            { id: 13, n: "excludehomepage_dogear" },
            { id: 15, n: "lqm_dogear" },
            { id: 17, n: "mvc" },
            { id: 18, n: "ajax" },
            { id: 38, n: "devexpress_video" },
            { id: 39, n: "devmavens_sidebar" },
            { id: 40, n: "devmavens_offer" },
            { id: 44, n: "silverlight" },
            { id: 45, n: "wpf" },
            { id: 54, n: "csharp_articles" }
        ],

        MapLqmZoneToDartZone: function (requestData) {
            if (requestData.zone) {
                var found = false;
                var i = 0;
                while (i < this.zoneInfo.length && !found) {
                    if (this.zoneInfo[i].id == requestData.zone) {
                        requestData.zonename = this.zoneInfo[i].n;
                        found = true;
                    }
                    i++;
                }
                if (!found) {
                    if (isNaN(requestData.zone))
                        requestData.zonename = requestData.zone.toLowerCase();
                    else
                        requestData.zonename = "ron";
                }
            }
            else
                requestData.zonename = "ron";
        },

        // End of Mapping from Lake Quincy to DART information 
        //-----------------------------------------------------------------------------------------

        GetDocHeight: function (doc) {
            return doc.height || doc.body && doc.body.scrollHeight;
        },

        // TODO: get rid of jQuery
        HideRefs: function (doc, theAdDiv, requestData) {
            var self = this;
            var context;
            // replace the div contents with the iframe contents for 1xN sizes. 
            // this overwrites the iframe. 
            if (requestData.format.indexOf("1x") === 0) {
                theAdDiv.innerHTML = doc.body.innerHTML;
                context = theAdDiv;
            }
            else
                context = doc;

            var links = context.getElementsByTagName("a");

            var modifyLinks = function (link) {
                var href = link.href;

                var ourHref = window.location.protocol + '//a.lakequincy.com/' + 
                                self.GetRandom(4, 16) + "-" + self.GetRandom(7, 16);

                link.href = ourHref;

                var mouseDownHandler = function () {
                    link.href = href;
                };

                var mouseUpHandler = function () {
                    link.href = ourHref;
                };

                if (link.addEventListener) {
                    link.addEventListener("mousedown", mouseDownHandler, false);
                    link.addEventListener("mouseover", mouseUpHandler, false);
                }
                else
                    try {
                        link.attachEvent("onmousedown", mouseDownHandler);
                        link.attachEvent("onmouseover", mouseUpHandler);
                    }
                    catch (e) { }
            };

            for (var i = 0; i < links.length; i++) {
                modifyLinks(links[i]);
            }
        }
    };
}

// -----------------------------------------------------------------------------------------------
// (C) Copyright 2011 by Lake Quincy Media. All rights reserved.
//
// Substitute for the Lake Quincy s.js which serves Ads from DART.
//   
// use:
//     <script type="text/javascript"> 
//     <!-- 
//     lqm_channel=1;
//     lqm_publisher=68;
//     lqm_zone=1;
//     lqm_format=7;
//     //-->
//     </script>
//     <script type="text/javascript" src="http://a.lakequincy.com/s.js"></script>
// ----------------------------------------------------------------------------------------------- 

if (typeof LqmAds.CreateAd !== 'function') 
{
    LqmAds.CreateAd = function ()
        {
            if ( lqm_format && lqm_publisher )
            {
                if ( this.PageRandomNumber == null )
                    this.PageRandomNumber = this.GetRandom( 32, 16 );

                if ( this.PageSearchTerms == null )
                    this.PageSearchTerms = this.GetQueryTerms();

                var requestData = { height: 0, width: 0, format: lqm_format, publisher: lqm_publisher };
                requestData.zone = lqm_zone || 1;

                // and the Ad count
                requestData.tile = this.Tile++;

                // and open new window when clicked
                requestData.target = "_blank";

                // add and search engine query terms to the tags parameter
                if ( this.PageSearchTerms && this.PageSearchTerms != "" )
                {
                    requestData.tags = this.PageSearchTerms;
                }

                this.DetermineTagSize( requestData );
                this.MapLqmIdsToDart( requestData );

                document.write( this.BuildJavaScriptTag( requestData ) );
            }

            // reset the parameters
            var n = null;
            lqm_format = n;
            lqm_publisher = n;
            lqm_zone = n;
        };
}

//---------------------------------------------------------------------------------------------
// do the work
LqmAds.CreateAd();
// end of work
//---------------------------------------------------------------------------------------------

