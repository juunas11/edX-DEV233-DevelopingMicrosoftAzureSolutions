using Contoso.Events.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Contoso.Events.Data
{
    public class EventsContextInitializer : CreateDatabaseIfNotExists<EventsContext>
    {
        protected override void Seed(EventsContext context)
        {
            context.Events.AddRange(
                new List<Event>
                {
                    new Event
                    {
                      EventKey = "ITProRoundtable19",
                      StartTime = new DateTime(2019, 7, 15, 10, 00, 00),
                      EndTime = new DateTime(2019, 7, 19, 20, 00, 00),
                      Title = "IT Professional Roundtable 2019",
                      Description = "Despite sea changes in cloud computing, device proliferation, and the explosion of data, IT pros still live for one simple thing: to deliver amazing experiences for their customers and end-users. This event will bring together the brightest minds in the industry to share best practices and solve common problems.",
                      Location = new Location
                      {
                          Name = "Boston Convention and Exhibition Center",
                          StreetAddress = "415 Summer Street",
                          City = "Boston",
                          State ="MA",
                          ZipCode = "02210"
                      },
                      Registrants = new List<Registration>
                      {
                          new Registration
                        {
                          FirstName = "Ayers",
                          LastName = "Sandoval",
                          EmailAddress = "ayerssandoval@example.com",
                          Referrer = Referrers.SearchEngine,
                          Timestamp = new DateTime(2019, 04, 10, 08, 30, 00)
                        },
                        new Registration
                        {
                          FirstName = "Felecia",
                          LastName = "Aguilar",
                          EmailAddress = "feleciaaguilar@example.com",
                          Referrer = Referrers.WordofMouth,
                          Timestamp = new DateTime(2019, 03, 24, 09, 32, 00)
                        },
                        new Registration
                        {
                          FirstName = "Lora",
                          LastName = "Cobb",
                          EmailAddress = "loracobb@example.com",
                          Referrer = Referrers.Email,
                          Timestamp = new DateTime(2019, 04, 08, 02, 28, 00)
                        },
                        new Registration
                        {
                          FirstName = "Alba",
                          LastName = "Melton",
                          EmailAddress = "albamelton@example.com",
                          Referrer = Referrers.SearchEngine,
                          Timestamp = new DateTime(2019, 06, 21, 03, 57, 00)
                        },
                        new Registration
                        {
                          FirstName = "Kerri",
                          LastName = "Moody",
                          EmailAddress = "kerrimoody@example.com",
                          Referrer = Referrers.WordofMouth,
                          Timestamp = new DateTime(2019, 06, 13, 05, 11, 00)
                        }
                      }
                    },
                    new Event
                    {
                      EventKey = "CloudDeveloperSummit17",
                      StartTime = new DateTime(2017, 11, 20, 09, 00, 00),
                      EndTime = new DateTime(2017, 11, 22, 14, 00, 00),
                      Title = "Cloud Developer Summit 2017",
                      Description = "Over 70 technical training sessions covering a range of topics across Microsoft Azure and the hybrid platform including security, networking, data, storage, identity, mobile, cloud infrastructure, management, devops, app platform, productivity, collaboration and more.",
                      Location = new Location
                      {
                          Name = "Walter E. Washington Convention Center",
                          StreetAddress = "801 Mount Vernon Place NW",
                          City = "Washington",
                          State ="DC",
                          ZipCode = "20001"
                      },
                      Registrants = new List<Registration>
                      {
                          new Registration
                        {
                          FirstName = "Jami",
                          LastName = "Swanson",
                          EmailAddress = "jamiswanson@example.com",
                          Referrer = Referrers.SearchEngine,
                          Timestamp = new DateTime(2018, 06, 27, 10, 32, 00)
                        },
                        new Registration
                        {
                          FirstName = "Marina",
                          LastName = "Hutchinson",
                          EmailAddress = "marinahutchinson@example.com",
                          Referrer = Referrers.Email,
                          Timestamp = new DateTime(2018, 09, 13, 11, 07, 00)
                        },
                        new Registration
                        {
                          FirstName = "Carla",
                          LastName = "Rollins",
                          EmailAddress = "carlarollins@example.com",
                          Referrer = Referrers.Email,
                          Timestamp = new DateTime(2018, 08, 07, 05, 49, 00)
                        },
                        new Registration
                        {
                          FirstName = "Jackie",
                          LastName = "Knight",
                          EmailAddress = "jackieknight@example.com",
                          Referrer = Referrers.WordofMouth,
                          Timestamp = new DateTime(2018, 09, 15, 02, 46, 00)
                        },
                        new Registration
                        {
                          FirstName = "Lillian",
                          LastName = "Kaufman",
                          EmailAddress = "lilliankaufman@example.com",
                          Referrer = Referrers.SocialMedia,
                          Timestamp = new DateTime(2018, 11, 04, 04, 15, 00)
                        }
                      }
                    },
                    new Event
                    {
                      EventKey = "SharePointExpertsSymposium18",
                      StartTime = new DateTime(2018, 4, 8, 11, 00, 00),
                      EndTime = new DateTime(2018, 4, 11, 18, 00, 00),
                      Title = "SharePoint Experts Symposium 2018",
                      Description = "Join worldwide experts in modern platforms such as Office 365, SharePoint and Yammer as we talk about the future of each platform. The goal of this week is to help you design and implement solutions and apps that will drive innovation and better position your company for the future.",
                      Location = new Location
                      {
                          Name = "Las Vegas Convention Center",
                          StreetAddress = "3150 Paradise Road",
                          City = "Las Vegas",
                          State ="NV",
                          ZipCode = "89109"
                      },
                      Registrants = new List<Registration>
                      {
                          new Registration
                        {
                            FirstName = "Jerry",
                            LastName = "English",
                            EmailAddress = "jerryenglish@example.com",
                            Referrer = Referrers.SearchEngine,
                            Timestamp = new DateTime(2018, 02, 09, 03, 28, 00)
                        },
                        new Registration
                        {
                            FirstName = "Katheryn",
                            LastName = "Finley",
                            EmailAddress = "katherynfinley@example.com",
                            Referrer = Referrers.SocialMedia,
                            Timestamp = new DateTime(2017, 11, 03, 05, 14, 00)
                        },
                        new Registration
                        {
                            FirstName = "Elaine",
                            LastName = "Pate",
                            EmailAddress = "elainepate@example.com",
                            Referrer = Referrers.WordofMouth,
                            Timestamp = new DateTime(2018, 03, 17, 09, 19, 00)
                        },
                        new Registration
                        {
                            FirstName = "Deloris",
                            LastName = "Owens",
                            EmailAddress = "delorisowens@example.com",
                            Referrer = Referrers.Email,
                            Timestamp = new DateTime(2018, 01, 12, 10, 46, 00)
                        },
                        new Registration
                        {
                            FirstName = "Cristina",
                            LastName = "Carpenter",
                            EmailAddress = "cristinacarpenter@example.com",
                            Referrer = Referrers.SearchEngine,
                            Timestamp = new DateTime(2018, 04, 02, 09, 59, 00)
                        }
                      }
                    }
                }
            );
        }
    }
}