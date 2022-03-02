using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;

namespace TwoTaskWebAPI.Test.Helpers
{
    public static class DataHelper
    {
        public static List<TodoTaskModel> GetAllTodoTasks()
        {
            return new List<TodoTaskModel>
            {
                new TodoTaskModel
                {
                    Id = 1,
                    ListId = 1,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    RegionId = 1,
                    Description = "milk, eggs, apples, orangejuice",
                    Title = "go shopping",
                    Priority = 1,
                    Status = "in progress",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                    
                },
                new TodoTaskModel
                {
                    Id = 3,
                    ListId = 1,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    RegionId = 1,
                    Description = "warm clothes",
                    Title = "go shopping",
                    Priority = 1,
                    Status = "in progress",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")

                },
                new TodoTaskModel
                {
                    Id = 2,
                    ListId = 2,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    RegionId = 2,
                    Description = "all rooms",
                    Title = "clean house",
                    Priority = 1,
                    Status = "in progress",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")

                }
            };
        }

        public static List<TodoTasksListModel> GetAllTodoTasksLists()
        {
            return new List<TodoTasksListModel>
            {
                new TodoTasksListModel
                {
                    Id = 1,
                    Name = "home",
                    CategoryId = 1,
                    IsArchived = false,
                    Colour = "blue",
                    Privacy = "private",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                    GroupId = 0
                },
                new TodoTasksListModel
                {
                    Id = 3,
                    Name = "work",
                    CategoryId = 2,
                    IsArchived = false,
                    Colour = "red",
                    Privacy = "semipublic",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                    GroupId = 1

                },
                new TodoTasksListModel
                {
                    Id = 2,
                    Name = "family",
                    CategoryId = 1,
                    IsArchived = false,
                    Colour = "green",
                    Privacy = "semipublic",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4"),
                    GroupId = 2

                }
            };
        }

        public static List<RegionModel> GetAllRegions()
        {
            return new List<RegionModel>
            {
                new RegionModel
                { 
                    Id = 1,
                    Name = "School",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new RegionModel
                {
                    Id = 3,
                    Name = "Home",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new RegionModel
                {
                    Id = 2,
                    Name = "Work",
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")
                }
            };
        }

        public static List<LocationModel> GetAllLocations()
        {
            return new List<LocationModel>
            {
                new LocationModel
                {
                    Id = 1,
                    RegionId = 1,
                    Latitude = 25.255785466556,
                    Longitude = 55.854525211455,
                    Radius = 10,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new LocationModel
                {
                    Id = 3,
                    RegionId = 2,
                    Latitude = 35.255785466556,
                    Longitude = 55.854525211455,
                    Radius = 1,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new LocationModel
                {
                    Id = 2,
                    RegionId = 3,
                    Latitude = 25.255785466556,
                    Longitude = 35.854525211455,
                    Radius = 5,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")
                }
            };
        }
        public static List<ListsCategoryModel> GetAllListsCategories()
        {
            return new List<ListsCategoryModel>
            {
                new ListsCategoryModel
                {
                    Id = 1,
                    Name = "school",
                    CategoryId = 0,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new ListsCategoryModel
                {
                    Id = 3,
                    Name = "work",
                    CategoryId = 1,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new ListsCategoryModel
                {
                    Id = 2,
                    Name = "home",
                    CategoryId = 0,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")
                }
            };
        }
        public static List<GroupModel> GetAllGroups()
        {
            return new List<GroupModel>
            {
                new GroupModel
                {
                    Id = 1,
                    Name = "family",
                    OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new GroupModel
                {
                    Id = 3,
                    Name = "class 2a",
                    OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new GroupModel
                {
                    Id = 2,
                    Name = "friends",
                    OwnerId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")
                }
            };
        }

        public static List<UsersInGroupModel> GetAllUsersFromGroup()
        {
            return new List<UsersInGroupModel>
            {
                new UsersInGroupModel
                {
                    Id = 1,
                    GroupId = 1,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new UsersInGroupModel
                {
                    Id = 3,
                    GroupId = 3,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5")
                },
                new UsersInGroupModel
                {
                    Id = 2,
                    GroupId = 2,
                    UserId = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4")
                }
            };
        }

        public static List<UserModel> GetAllUsers()
        {
            string stringPasswordFromSQL = "0xB7262C9434E7B554D177525454EE70331F3653704A64D64F0D59C43011CE69CB0525EAE05AC335022C693231CD0218590895748EC38F701C167CA3AD63CD4743";
            List<byte> byteList = new List<byte>();

            string hexPart = stringPasswordFromSQL.Substring(2);
            for (int i = 0; i < hexPart.Length / 2; i++)
            {
                string hexNumber = hexPart.Substring(i * 2, 2);
                byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
            }

            byte[] originalPassword = byteList.ToArray();

            string stringSaltFromSQL = "0x365DF0A0B9F55CFDE689E58BC40567C026E631BFF5C5F2D2C4C6EFAFC8AB593E79860C23F7381E7953F5E474C321EE99C7701D173CA8C044895A9E0E9271F8B764474EDBAF765A8673CBFD682FA851F84FA4D3269522042A673DB2B898DAB937F7AFCD51B155E269A1822C7AD795FCBEC161D5EC3DFB665ECE9FB1CDEF5BAAA4";
           
            List<byte> byteListForSalt = new List<byte>();

            string hexPartForSalt = stringSaltFromSQL.Substring(2);
            for (int i = 0; i < hexPartForSalt.Length / 2; i++)
            {
                string hexNumberForSalt = hexPartForSalt.Substring(i * 2, 2);
                byteListForSalt.Add((byte)Convert.ToInt32(hexNumberForSalt, 16));
            }

            byte[] originalSalt= byteListForSalt.ToArray();

            return new List<UserModel>
            {
                new UserModel
                {
                    UserName = "tom",
                    Id = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff5"),
                    Email = "tom@gmail.com",
                    Password = originalPassword,
                    PasswordSalt = originalSalt
                },
                new UserModel
                {
                    UserName = "maria",
                    Id = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff4"),
                    Email = "maria@gmail.com",
                    Password = originalPassword,
                    PasswordSalt = originalSalt
                },
                new UserModel
                {
                    UserName = "jim",
                    Id = Guid.Parse("5418b246-9d9f-4d37-a6d9-a283a2169ff3"),
                    Email = "jim@gmail.com",
                    Password = originalPassword,
                    PasswordSalt = originalSalt
                }
            };
        }
    }
}
