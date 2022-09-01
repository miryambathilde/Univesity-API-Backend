using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {

        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza,",
                "Seat Leon"
            };


            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SELECT AUDIS)
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audiList);
            }
        }

        // 3. Number examples

        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each number multiply by 3
            // Take all number, except 9
            // Order number by ascending value

            var processedNumberList =
                numbers
                    .Select(num => num * 3) // {3, 6, 9, ...}
                    .Where(num => num != 9) // { all except 9}
                    .OrderBy(num => num); // { and now we order by ascending order }
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c",
            };

            // 1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or value by default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // " " or first element that contains "z"

            // 5. Last element that contains "z" or value by default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z")); // " " or last element that contains "z"

            // 6. Single Values
            var uniqueTexts = textList.SingleOrDefault();

            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6};

            // Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); // { 4, 8}
        }


        static public void MultipleSelector()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Miryam",
                            Email = "mail@example.es",
                            Salary = 3000

                        },
                         new Employee
                        {
                            Id = 2,
                            Name = "Pepe",
                            Email = "pepe@example.es",
                            Salary = 1000

                        },
                         new Employee
                        {
                            Id = 3,
                            Name = "Juanjo",
                            Email = "juanjo@example.es",
                            Salary = 2000

                        }
                    }
                },
                 new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "mail@example.es",
                            Salary = 3000

                        },
                         new Employee
                        {
                            Id = 5,
                            Name = "Maria",
                            Email = "maria@example.es",
                            Salary = 1500

                        },
                         new Employee
                        {
                            Id = 6,
                            Name = "Marta",
                            Email = "marta@example.es",
                            Salary = 4000

                        }
                    }
                },
            };

            // Obtain all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any list is empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // All employees which their the salary is at least 1000€
            bool hasEmployeeWithSalaryMoreOrEqualThan1000 =
                enterprises.Any(
                    enterprise => enterprise.Employees.Any(employee => employee.Salary >= 1000));
        }

        static public void linqCollection()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement}
                );



            // OUTER JOIN - LEFT JOIN
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            // simply way

            var leftOuterJoinSimply = from element in firstList
                                    from secondElement in secondList.Where(e => e == element).DefaultIfEmpty()
                                    select new { Element = element, SecondElement = secondElement };


            // OUTER JOIN - RIGHT JOIN
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            // JOIN all left and rigt join
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // SKIP functions

            var skipTwoFirstValues = myList.Skip(2); // { 3,4,5,6,7,8,9,10}

            var skipLastTwoValues = myList.SkipLast(2); // { 1,2,3,4,5,6,7,8 } 

            var skipWhileSmallerThanFour = myList.SkipWhile(num => num < 4); // { 4,5,6,7,8 }

            // TAKE functions

            var takeTwoFirstValues = myList.Take(2); // { 1,2 }

            var takeLastTwoValues = myList.TakeLast(2); // { 9, 10 } 

            var takeWhileSmallerThanFour = myList.TakeWhile(num => num < 4); // { 1,2,3 }
        }

        // TODO:

        // Variables

        // ZIP Function

        // Repeat function
        
        // ALL

        // Aggregate

        // Distinct

        // GroupBy


    }

}