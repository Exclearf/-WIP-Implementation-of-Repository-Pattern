using RepoPattern.DTO;
using RepoPattern.Models;
using RepoPattern.Repository;
using RepoPattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepoPattern.Controllers
{
    public class InputController : IInputController
    {
        private IInputService _inputService;
        private bool _isCaseSensitive;
        private ConsoleColor _color;
        private Dictionary<string, Action> avaliableFunctions;
        private char defaultLineChar = '═';
        private char defaultLineSeparatorChar = '─';
        private string defaultCornerString = "╒╕╘╛";
        private int lineLength;
        private ConsoleColor initialConsoleColor = ConsoleColor.White;

        public void AddExercise()
        {
            throw new NotImplementedException();
        }

        public void AddExerciseMenu()
        {
            Console.Clear();
            
            List<string?> list = ShowAllEntries(typeof(ExerciseDTO));

            Console.ReadKey();
        }

        public List<string?> ShowAllEntries(Type type)
        {
            DrawLine();
            showLeftChar();
            Console.WriteLine();
            List<string?> list = new();

            int height = 2;
            int leftOffset = 0;

            foreach (var propertyName in type.GetProperties())
            {
                list.Add(propertyName.ToString()?.Split(' ').Last());
                showLeftChar();
                Console.WriteLine($" {list.Last()}");
                showLeftChar();
                Console.WriteLine();
                height++;
                if (list.Last().Length > leftOffset)
                    leftOffset = list.Last().Length;
            }
            DrawLine(isUpperLine: false);
            var propertiesIndexes = showRightChar(height, leftOffset);


            List<string> input = new();

            foreach(var index in propertiesIndexes)
            {
                Console.SetCursorPosition(leftOffset + ((lineLength - leftOffset) / 3), index);
                input.Add(Console.ReadLine());
            }

            Console.ReadKey();

            _inputService.Add(new Exercise()
            {
                DateStart = DateTime.TryParse(input[0], out _) ? DateTime.Parse(input[0]) : DateTime.Now,
                DateEnd = DateTime.TryParse(input[1], out _) ? DateTime.Parse(input[0]) : DateTime.Now,
                Duration = TimeSpan.Parse(input[2]),
                Comments = input[3],
            });

            return list;
        }


        public List<int> showRightChar(int amount, int leftOffset, string cornersString = "", char lineSeparatorChar = Char.MinValue)
        {
            if (cornersString == "")
                cornersString = defaultCornerString;
            if (lineSeparatorChar == Char.MinValue)
                lineSeparatorChar = defaultLineSeparatorChar;

            var cursorPosition = Console.GetCursorPosition();
            var colorFrColor = Console.ForegroundColor;
            var curHeight = 0;
            List<int> indexes = new();

            leftOffset = lineLength + 1;

            Console.SetCursorPosition(leftOffset, curHeight++);
            Console.ForegroundColor = _color;
            Console.Write(cornersString[1]);

            for (int i = 1; i < amount*2-2; i++)
            {
                Console.SetCursorPosition(leftOffset, curHeight++);
                if (i > 2 && i < amount * 2 - 3 && i % 2 != 0)
                {
                    indexes.Add(curHeight - 2);
                    Console.SetCursorPosition(0, curHeight-1);
                    Console.Write($"├{new string(lineSeparatorChar, leftOffset - 1)}┤");
                }
                else
                    Console.Write("│");
            }
            Console.SetCursorPosition(leftOffset, curHeight++);
            Console.Write(cornersString[3]);

            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top+1);
            Console.ForegroundColor = colorFrColor;

            //Add item which is missing

            indexes.Add(indexes.Last() + 2);

            return indexes;
        }

        public void DisplayAll()
        {
            throw new NotImplementedException();
        }

        public void DisplayAllMenu()
        {
            throw new NotImplementedException();
        }

        public void EndSession()
        {
            throw new NotImplementedException();
        }

        public void RemoveExercise()
        {
            throw new NotImplementedException();
        }
        public void RemoveExerciseMenu()
        {
            throw new NotImplementedException();
        }

        public void DrawLine(int length = 30, char lineChar = Char.MinValue, string cornersString = "", bool isUpperLine = true)
        {
            lineLength = length;
            if (lineChar == Char.MinValue)
                lineChar = defaultLineChar;
            if (cornersString == "")
                cornersString = defaultCornerString;

            var str = new StringBuilder(new string(lineChar, length));

            if (isUpperLine)
            {
                str.Insert(0, cornersString[0]);
                //str.Append(cornersString[1]);
            }
            else
            {
                str.Insert(0, cornersString[2]);
                //str.Append(cornersString[3]);
            }
            var colorFrColor = initialConsoleColor;
            Console.ForegroundColor = _color;
            Console.WriteLine(str);
            Console.ForegroundColor = colorFrColor;
        }

        public void EditExercise()
        {
            throw new NotImplementedException();
        }
        public void EditExerciseMenu()
        {
            throw new NotImplementedException();
        }

        public void showMenuOptions()
        {
            showLeftChar();
            Console.WriteLine();
            foreach (var key in avaliableFunctions.Keys)
            {
                showLeftChar();
                Console.WriteLine($" {key}");
                showLeftChar();
                Console.WriteLine();
            }
        }

        public void showLeftChar()
        {
            var colorFrColor = Console.ForegroundColor;
            Console.ForegroundColor = _color;
            Console.Write("│");
            Console.ForegroundColor = colorFrColor;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                DrawLine(isUpperLine: true);
                showMenuOptions();
                DrawLine(isUpperLine: false);
                Console.Write("Input: ");
                var userInput = Console.ReadLine()?.Trim();
                if (userInput != null) {
                    try
                    {
                        if (_isCaseSensitive == false)
                        {
                            userInput = avaliableFunctions.Keys.First(key => key.ToLower() == userInput.ToLower());
                        }
                        avaliableFunctions[userInput]();
                    }
                    catch
                    {
                        Console.WriteLine("No such option!");
                    }
                }
                Console.ReadKey();
            }
        }

        public void Start(IInputService inputService, bool isCaseSensitive = false, ConsoleColor color = ConsoleColor.Green)
        {
            avaliableFunctions = new(){
            { "Add", () => AddExerciseMenu()},
            { "Display", () => DisplayAllMenu()},
            { "Edit", () => EditExerciseMenu()},
            { "Delete", () => RemoveExerciseMenu()},
            { "Exit", () => EndSession()},
            };
        _color = color;
            _inputService = inputService;
            Console.Title = "Repository Pattern Practice";
            ShowMenu();
        }
    }
}
