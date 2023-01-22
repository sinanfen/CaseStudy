using CaseStudy.Models;
using static Azure.Core.HttpHeader;

namespace CaseStudy.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        new User()
                        {
                           FullName="Ali Veli",

                        },
                        new User()
                        {
                           FullName="Deniz Mehmet",

                        },
                        new User()
                        {
                           FullName="Ahmet Hasan",

                        },
                        new User()
                        {
                           FullName="Bekir Özcan",

                        },
                        new User()
                        {
                           FullName="Cemil Bayram",

                        }
                    });
                    context.SaveChanges();
                };
                if (!context.Notes.Any())
                {
                    context.Notes.AddRange(new List<Note>()
                    {
                        new Note()
                        {
                           Content="Deneme not 1",
                           UserId=1,

                        },
                        new Note()
                        {
                           Content="Deneme not 2",
                           UserId=2,

                        },
                        new Note()
                        {
                           Content="Deneme not 3",
                           UserId=3,

                        },
                        new Note()
                        {
                           Content="Deneme not 4",
                           UserId=4,

                        },
                        new Note()
                        {
                           Content="Deneme not 5",
                           UserId=5,

                        }
                    });
                    context.SaveChanges();
                };
                if (!context.NoteDetails.Any())
                {
                    context.NoteDetails.AddRange(new List<NoteDetail>()
                    {
                        new NoteDetail()
                        {
                          Content="Deneme not detay 1",
                          NoteId=1,
                          UserId=1
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 2",
                          NoteId=2,
                          UserId=2
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 3",
                          NoteId=3,
                          UserId=3
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 4",
                          NoteId=4,
                          UserId=4
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 5",
                          NoteId=5,
                          UserId=5
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 6",
                          NoteId=1,
                          UserId=1
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 7",
                          NoteId=2,
                          UserId=2
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 8",
                          NoteId=3,
                          UserId=3
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 9",
                          NoteId=4,
                          UserId=4
                        },
                        new NoteDetail()
                        {
                          Content="Deneme not detay 10",
                          NoteId=5,
                          UserId=5
                        }
                    });
                    context.SaveChanges();
                };
            }
        }
    }
}
