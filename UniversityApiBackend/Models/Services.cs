using System;
using System.Linq;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Models
{
    public class Services
    {

        // Find users by email

        static public void userByEmail(string uEmail)
        {
            var users = new List<User>();
            
            var userByEmailList = from user 
                                  in users 
                                  where user.Email == uEmail select user;
        }

        // Find students older than 18 (legal age)

        static public void StudentsOlderThan18()
        {
            var students = new List<Student>();

            var StudentsOlderThan18List = from student in students
                                          where student.DOB.Year > (DateTime.Now.Year - 18)
                                          select student;
        }

        // Find students than have at least one course

        static public void StudentAtLeastOneCourse()
        {
            var students = new List<Student>();

            var courses = new List<Course>();

            var StudentAtLeastOneCourseList = from student in students 
                                              where student.Courses.Count > 0 select student;

        }

        // Find courses of a determined level that are of a determined category

        static public void CoursesWithALevelAndCategoryDeterminated(Level levelToFind, Category categoryToFind)
        {
            var courses = new List<Course>();

            var CoursesWithALevelAndCategoryDeterminatedList = from course in courses
                                                               where course.Level == levelToFind
                                                               where course.Categories == categoryToFind
                                                               select course;
        }

        // Search courses with no students

        static public void CoursesWithNoStudents()
        {
            var courses = new List<Course>();

            var coursesWithNoStudentsList = from course in courses
                                            where course.Students.Count < 1 
                                            select course;
        }



    }
}
