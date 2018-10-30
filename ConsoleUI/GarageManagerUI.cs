using System;
using System.Collections.Generic;
using System.Linq;
using GarageLogic;
using GarageLogic.Interfaces;
using GarageLogic.Models;
using GarageLogic.Operations;

namespace ConsoleUI
{
    public class GarageManagerUi
    {
        private readonly IOrderedEnumerable<Operation> r_Operations;
        private Operation m_SelectedOperation;

        public GarageManagerUi()
        {
            IGarageManager garageManager = new GarageManager();
            r_Operations = garageManager.GetOperations().OrderBy(i_O => i_O.Index);
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Design Patterns Garage!");

            while(true)
            {
                printOperationsMenu();
                string input = Console.ReadLine();
                int operationIndex;
                if(!int.TryParse(input, out operationIndex))
                {
                    Console.WriteLine("Invalid Input\n");
                }
                else
                {
                    m_SelectedOperation = r_Operations.ElementAtOrDefault(operationIndex - 1);
                    if(m_SelectedOperation != null)
                    {
                        executeOperation();
                    }
                    else
                    {
                        Console.WriteLine("Operation doesn't exists\n");
                    }
                }
            }
        }

        private void printOperationsMenu()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Please enter the operation number you want:\n");

            foreach(Operation operation in r_Operations)
            {
                Console.WriteLine(operation);
            }
        }

        private void executeOperation()
        {
            var selectedOperation = r_Operations.ElementAtOrDefault(m_SelectedOperation.Index - 1);
            if(selectedOperation != null)
            {
                foreach(KeyValuePair<string, Func<string, eOperationStatus>> instruction in selectedOperation.Instructions)
                {
                    eOperationStatus currentOperationStatus = eOperationStatus.Starting;
                    while(currentOperationStatus == eOperationStatus.Starting)
                    {
                        try
                        {
                            Console.WriteLine(instruction.Key);
                            string parameter = Console.ReadLine();
                            currentOperationStatus = instruction.Value.Invoke(parameter);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.Write(Environment.NewLine);
                        }
                    }
                    if(currentOperationStatus == eOperationStatus.CanProceedToSubMenu)
                    {
                        foreach(KeyValuePair<string, Func<string, eOperationStatus>> selectedOperationSubMenuInstruction in selectedOperation.SubMenuInstructions)
                        {
                            currentOperationStatus = eOperationStatus.Starting;
                            while (currentOperationStatus == eOperationStatus.Starting)
                            {
                                try
                                {
                                    Console.WriteLine(selectedOperationSubMenuInstruction.Key);
                                    string parameter = Console.ReadLine();
                                    currentOperationStatus = selectedOperationSubMenuInstruction.Value.Invoke(parameter);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.Write(Environment.NewLine);
                                }
                            }
                        }

                    }
                    if(currentOperationStatus == eOperationStatus.Completed)
                    {
                        Console.WriteLine(selectedOperation.m_OperationResult);
                    }
                }
            }
        }
    }
}
