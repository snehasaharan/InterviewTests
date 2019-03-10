using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly IGraduationTracker graduationTracker;
        public GraduationTrackerTests()
        {
            graduationTracker = new GraduationTracker();
        }

        #region TestData
        private Student SumaCumLaudeStudent
        {
            get
            {
                return new Student
                {
                    Id = 1,
                    Courses = new Course[]
                          {
                                new Course{Id = 1, Name = "Math", Mark=95 },
                                new Course{Id = 2, Name = "Science", Mark=95 },
                                new Course{Id = 3, Name = "Literature", Mark=95 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                          }
                };
            }
        }

        private Student MagnaCumLaudeStudent
        {
            get
            {
                return new Student
                {
                    Id = 2,
                    Courses = new Course[]
                           {
                                new Course{Id = 1, Name = "Math", Mark=81 },
                                new Course{Id = 2, Name = "Science", Mark=81 },
                                new Course{Id = 3, Name = "Literature", Mark=81 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=81 }
                           }
                };
            }
        }

        private Student AverageStudent
        {
            get
            {
                return new Student
                {
                    Id = 3,
                    Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=51 },
                            new Course{Id = 2, Name = "Science", Mark=51 },
                            new Course{Id = 3, Name = "Literature", Mark=51 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=51 }
                        }
                };
            }
        }
        private Student RemedialStudent
        {
            get
            {
                return new Student
                {
                    Id = 4,
                    Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=40 },
                            new Course{Id = 2, Name = "Science", Mark=40 },
                            new Course{Id = 3, Name = "Literature", Mark=40 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                        }
                };
            }
        }
        private Student[] Students
        {
            get
            {
                return new[]
                    {
                       new Student
                       {
                           Id = 1,
                           Courses = new Course[]
                           {
                                new Course{Id = 1, Name = "Math", Mark=95 },
                                new Course{Id = 2, Name = "Science", Mark=95 },
                                new Course{Id = 3, Name = "Literature", Mark=95 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                           }
                       },
                       new Student
                       {
                           Id = 2,
                           Courses = new Course[]
                           {
                                new Course{Id = 1, Name = "Math", Mark=80 },
                                new Course{Id = 2, Name = "Science", Mark=80 },
                                new Course{Id = 3, Name = "Literature", Mark=80 },
                                new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                           }
                       },
                    new Student
                    {
                        Id = 3,
                        Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=50 },
                            new Course{Id = 2, Name = "Science", Mark=50 },
                            new Course{Id = 3, Name = "Literature", Mark=50 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                        }
                    },
                    new Student
                    {
                        Id = 4,
                        Courses = new Course[]
                        {
                            new Course{Id = 1, Name = "Math", Mark=40 },
                            new Course{Id = 2, Name = "Science", Mark=40 },
                            new Course{Id = 3, Name = "Literature", Mark=40 },
                            new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                        }
                    }
                };
            }
        }

        private Diploma Diploma
        {
            get
            {
                return
               new Diploma
               {
                   Id = 1,
                   Credits = 4,
                   Requirements = new int[] { 100, 102, 103, 104 }
               };
            }
        }
        #endregion

        #region TestMethods
        [TestMethod]
        public void HasSomeGraduated()
        {
            var graduated = new List<Tuple<bool, STANDING>>();
            foreach (var student in Students)
            {
                graduated.Add(graduationTracker.HasGraduated(Diploma, student));
            }
            Assert.IsTrue(graduated.Any(g => g.Item1 == true));
        }
        [TestMethod]
        public void HasGraduatedWithSumaCumLaude()
        {
            var result = graduationTracker.HasGraduated(Diploma, SumaCumLaudeStudent);
            Assert.IsTrue(result.Item1 == true);
        }
        [TestMethod]
        public void HasGraduatedWithMagnaCumLaude()
        {
            var result = graduationTracker.HasGraduated(Diploma, MagnaCumLaudeStudent);
            Assert.IsTrue(result.Item1 == true);
        }
        [TestMethod]
        public void HasGraduatedWithAverage()
        {
            var result = graduationTracker.HasGraduated(Diploma, AverageStudent);
            Assert.IsTrue(result.Item1 == true);
        }
        [TestMethod]
        public void HasFailedWithRemedial()
        {
            var result = graduationTracker.HasGraduated(Diploma, RemedialStudent);
            Assert.IsTrue(!result.Item1 == true);
        }
        [TestMethod]
        public void HasNoneFailedWithRemedial()
        {
            var graduated = new List<Tuple<bool, STANDING>>();
            foreach (var student in Students)
            {
                graduated.Add(graduationTracker.HasGraduated(Diploma, student));
            }
            Assert.IsTrue(graduated.Any(g => !g.Item1 == true));
        }
        [TestMethod]
        public void HasAllGraduated()
        {
            var graduated = new List<Tuple<bool, STANDING>>();
            foreach (var student in Students)
            {
                graduated.Add(graduationTracker.HasGraduated(Diploma, student));
            }
            Assert.IsTrue(graduated.Any(g => g.Item1 == false));
        }
        #endregion
    }
}