using System;
using System.Collections.Generic;
using System.Text;

namespace Laba2
{
    public class Factory : IComparable<Factory>
    {
        private string _FactoryName;
        private int _CountOfDepartment;
        private int _CountOfMasters;
        private int _CountOfEmployees;
        private int _MasterSalary;
        private int _EmployeeSalary;
        private int _MounthBenefitFactoryFromMaster;
        private int _MounthBenefitFactoryFromEmployee;

        public Factory(string FactoryName, int CountOfDepartment, int MasterSalary, int EmployeeSalary) // конструктор с параметрами
        {
            _FactoryName = FactoryName;
            _CountOfDepartment = CountOfDepartment;
            _CountOfMasters = 0;
            _CountOfEmployees = 0;
            _MasterSalary = MasterSalary;
            _EmployeeSalary = EmployeeSalary;
            _MounthBenefitFactoryFromEmployee = 25;
            _MounthBenefitFactoryFromMaster = 100;
        }
        public Factory(Factory other) //конструктор копирования  
        {
            _FactoryName = other._FactoryName;
            _CountOfDepartment = other._CountOfDepartment;
            _CountOfMasters = other._CountOfMasters;
            _CountOfEmployees = other._CountOfEmployees;
            _MasterSalary = other._MasterSalary;
            _EmployeeSalary = other._EmployeeSalary;
            _MounthBenefitFactoryFromMaster = other._MounthBenefitFactoryFromMaster;
            _MounthBenefitFactoryFromEmployee = other._MounthBenefitFactoryFromEmployee;
        }
        public static Factory operator +(Factory A, Factory B) //оператор + 
        {
            var result = new Factory("", 0, 0, 0);

            result._FactoryName = A._FactoryName + " " + B._FactoryName;
            result._CountOfDepartment = A._CountOfDepartment + B._CountOfDepartment;
            result._CountOfEmployees = A._CountOfEmployees + B._CountOfEmployees;
            if (result._CountOfEmployees % 10 == 0)
                result._CountOfMasters = result._CountOfEmployees / 10;
            else
                result._CountOfMasters = result._CountOfEmployees / 10 + 1;
            result._MasterSalary = (A._MasterSalary + B._MasterSalary) / 2;
            result._EmployeeSalary = (A._EmployeeSalary + B._EmployeeSalary) / 2;
            result._MounthBenefitFactoryFromEmployee = (A._MounthBenefitFactoryFromEmployee + B._MounthBenefitFactoryFromEmployee) / 2;
            result._MounthBenefitFactoryFromMaster = (A._MounthBenefitFactoryFromMaster + B._MounthBenefitFactoryFromMaster) / 2;
            return result;
        }
        public void HireEmployee() //метод нанятия работника
        {
            if (_CountOfMasters == 0)
            {
                Console.WriteLine("Нет мастеров! Невозможно нанять рабочего");
                return;
            }
            if (_CountOfEmployees / _CountOfMasters == 10 && _CountOfEmployees % 10 == 0)
            {
                Console.WriteLine("Слишком много рабочих, необходимо нанять мастера!");
                return;
            }
            else
            {
                _CountOfEmployees++;
                Console.WriteLine("Рабочий успешно нанят!");
            }
        }
        public void HireMaster() //метод нанятия мастера
        {
            if (_CountOfMasters == 0)
            {
                _CountOfMasters++;
                return;
            }
            if (_CountOfEmployees % 10 == 0 && _CountOfEmployees / _CountOfMasters == 10)
            {
                _CountOfMasters++;
                Console.WriteLine("Мастер успешно нанят, нанимайте рабочих!");
                return;
            }
            else
            {
                Console.WriteLine("Слишком мало рабочих для нанятия мастера!");
            }
        }
        //////  
        public void DismissEmployee() //метод увольнения работника
        {
            if (_CountOfEmployees == 0)
                return;
            _CountOfEmployees--;
            if (_CountOfMasters * 10 - _CountOfEmployees >= 10)
                _CountOfMasters--;
        }
        public void DismissMaster() //метод увольнения мастера
        {
            if (_CountOfMasters == 0)
                return;
            _CountOfMasters--;
            while (_CountOfEmployees - _CountOfMasters * 10 != 0)
            {
                _CountOfEmployees--;
            }
        }
        public int CompareTo(Factory obj) //реализация интерфейса IComparable, метод сравнения заводов
        {
            if (obj == null) return 1;
            if (_CountOfDepartment == obj._CountOfDepartment && _MounthBenefitFactoryFromEmployee + _MounthBenefitFactoryFromMaster == obj._MounthBenefitFactoryFromEmployee + obj._MounthBenefitFactoryFromMaster)
            {
                Console.WriteLine("Заводы имеют одинаковое кол-во цехов и прибыль!");
                return 0;
            }
            else if (_MounthBenefitFactoryFromEmployee + _MounthBenefitFactoryFromMaster == obj._MounthBenefitFactoryFromEmployee + obj._MounthBenefitFactoryFromMaster)
            {
                Console.WriteLine($"Заводы получают одинаковую прибыль!");
                return 0;
            }
            else if (_MounthBenefitFactoryFromEmployee + _MounthBenefitFactoryFromMaster > obj._MounthBenefitFactoryFromEmployee + obj._MounthBenefitFactoryFromMaster)
            {
                Console.WriteLine($"Завод {_FactoryName} получает больше прибыли!");
                return 1;
            }
            else
            {
                Console.WriteLine($"Завод {obj._FactoryName} получает больше прибыли!");
                return -1;
            }
        }
    }
}
